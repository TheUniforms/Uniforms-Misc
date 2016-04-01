#!/usr/bin/env python
"""Save resized images from source directory to one or
multiple destinations.

Requirements:

    - Python 2.7+
    - YAML parser library
    - ImageMagic + Wand or Pillow library

If you want to use ImageMagic:

    apt-get install libmagickwand-dev
    pip install PyYAML Wand

If you want to use Pillow:

    pip install pillow PyYAML

"""
import os


class DirResizer(object):
    """Save resized images from `src` to `dst` directory,
    applying `scale` and renaming file with `name_format`.

    Arguments:

        src -- source directory
        dst -- destination directory
        scale -- destination images scale, < 1.0
        name_format -- string format for file names,
                       accepts {name} and {ext} tokens
        imagemagic -- use ImageMagic or not (use Pillow then)

    Usage example:

        # Retina resizer: take 3x images and make 2x resizes
        resizer = DirResizer('../Resources', '../iOS/Resources',
                             2.0/3.0, '{name}@2x.{ext}')
        resizer.run()

    """
    def __init__(self, src, dst, scale, name_format,
                 imagemagic=True, nohyphens=False):
        self.src = os.path.realpath(src)
        self.dst = os.path.realpath(dst)
        self.scale = scale
        self.name_format = name_format
        self.imagemagic = imagemagic
        self.nohyphens = nohyphens

        assert dst and (self.dst != self.src),\
               "Error, output dir and input dir must be different!"

    def run(self):
        try:
            os.makedirs(self.dst)
        except OSError:
            pass

        for item in os.listdir(self.src):
            file_path = os.path.join(self.src, item)
            name, ext = os.path.splitext(item)

            if not os.path.isfile(file_path):
                continue

            if not ext.lower() in ('.png', '.jpg', 'jpeg'):
                continue

            out_name = self.name_format.format(name=name,
                                               ext=ext.lstrip('.'))
            
            if self.nohyphens:
                # Android platform does not allow hyphens in resources
                # file names!!!
                out_name = out_name.replace('-', '_')

            out_file = os.path.join(self.dst, out_name)

            if self.imagemagic:
                self.resize_imagemagic(file_path, out_file)
            else:
                self.resize_pillow(file_path, out_file)

    def resize_imagemagic(self, file_path, out_file):
        from wand.image import Image

        with Image(filename=file_path) as im:
            im.resize(int(im.size[0] * self.scale + 0.5),
                      int(im.size[1] * self.scale + 0.5))
            # if im.depth != 8:
            #     print(im.depth)
            im.depth = 8
            im.save(filename=out_file)

    def resize_pillow(self, file_path, out_file):
        from PIL import Image

        im = Image.open(file_path)
        size = (int(im.size[0] * self.scale + 0.5),
                int(im.size[1] * self.scale + 0.5))
        im_resized = im.resize(size, Image.ANTIALIAS)
        im_resized.save(out_file, optimize=True)


class Resizer(object):
    """Bulk resizer.

    Arguments:

        src -- source directory
        base -- base image scale at source directory
        resizes -- list of dict configs for resizes with keys:
                   `dst`, `scale`, `name_format`

    Usage example:

        with open('resize_images.yml') as f:
            config = yaml.load(f)
        resizer = Resizer('../Resources', 3.0, config['resizes'])
        resizer.run()

    """
    def __init__(self, src, base, resizes, imagemagic=True):
        self.src = src
        self.base = base
        self.resizes = resizes
        self.imagemagic = imagemagic

    def run(self):
        for x in self.resizes:
            resize = x.copy()
            resize.update({
                'src': self.src,
                'scale': x['scale'] / self.base,
                'imagemagic': self.imagemagic,
            })
            resizer = DirResizer(**resize)
            resizer.run()


if __name__ == '__main__':
    import yaml

    with open('resize_images.yml') as f:
        config = yaml.load(f)

    print(config)

    resizer = Resizer(config['src'], config['base'], config['resizes'],
                      imagemagic=config.get('imagemagic', True))
    resizer.run()
