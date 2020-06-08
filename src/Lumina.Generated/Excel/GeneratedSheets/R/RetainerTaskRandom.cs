using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "RetainerTaskRandom", columnHash: 0x9ab94c53 )]
    public class RetainerTaskRandom : IExcelRow
    {
        // column defs from Sun, 10 May 2020 19:27:42 GMT


        // col: 00 offset: 0000
        public string Name;

        // col: 01 offset: 0004
        public short Requirement;


        public uint RowId { get; set; }
        public uint SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Name = parser.ReadOffset< string >( 0x0 );

            // col: 1 offset: 0004
            Requirement = parser.ReadOffset< short >( 0x4 );


        }
    }
}