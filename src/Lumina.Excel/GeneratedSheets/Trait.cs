// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "Trait", columnHash: 0x82f2127d )]
    public class Trait : IExcelRow
    {
        
        public SeString Name;
        public int Icon;
        public LazyRow< ClassJob > ClassJob;
        public byte Level;
        public LazyRow< Quest > Quest;
        public short Value;
        public LazyRow< ClassJobCategory > ClassJobCategory;
        public byte Unknown7;
        
        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina, Language language )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            Name = parser.ReadColumn< SeString >( 0 );
            Icon = parser.ReadColumn< int >( 1 );
            ClassJob = new LazyRow< ClassJob >( lumina, parser.ReadColumn< byte >( 2 ), language );
            Level = parser.ReadColumn< byte >( 3 );
            Quest = new LazyRow< Quest >( lumina, parser.ReadColumn< uint >( 4 ), language );
            Value = parser.ReadColumn< short >( 5 );
            ClassJobCategory = new LazyRow< ClassJobCategory >( lumina, parser.ReadColumn< byte >( 6 ), language );
            Unknown7 = parser.ReadColumn< byte >( 7 );
        }
    }
}