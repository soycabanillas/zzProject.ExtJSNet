using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using zzProject.MVCExtender.ExtJS.ClassesOld;

namespace zzProject.ExtJSNet.ExtJS.Classes.Ext.data
{
    public interface IStore
    {
        JsonCodeBlock RenderCreate();
        JsonCodeBlock RenderDefine(string storeName);
    }
}
