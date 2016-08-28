using System;
using System.Globalization;

namespace Uniforms.Core
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo(bool dialect = false);
    }
}

