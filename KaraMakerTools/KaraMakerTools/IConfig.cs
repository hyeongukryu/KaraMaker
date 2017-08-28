using System;
using System.Collections;
using System.Collections.Generic;

namespace KaraMakerTools
{
    interface IConfig
    {
        string GoogleSheetsKey { get; }
        IEnumerable<Tuple<string, string>> SheetNameAndKeyTuples { get; }
        string CipherKey { get; }
    }
}
