using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zzProject.MVCExtender.ExtJS.ClassesOld.Data;

namespace zzProject.MVCExtender.ExtJS.ClassesOld.Form.Field.ComboboxStore
{
    public enum QueryMode
    {
        local,
        remote
    }

    public interface IComboboxStore : IStore
    {
        string GetValueField();
        string GetDisplayField();
        QueryMode GetQueryMode();
    }
}
