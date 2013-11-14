using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Data
{
    public interface IStore
    {
        JsonCodeBlock RenderCreate();
        JsonCodeBlock RenderDefine(string storeName);
    }
}
