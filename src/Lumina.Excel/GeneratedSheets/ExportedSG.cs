// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "ExportedSG", columnHash: 0xdebb20e3 )]
    public class ExportedSG : IExcelRow
    {
        
        public SeString SgbPath;
        
        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina, Language language )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            SgbPath = parser.ReadColumn< SeString >( 0 );
        }
    }
}