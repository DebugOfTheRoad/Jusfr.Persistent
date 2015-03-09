using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jusfr.Persistent.NH {
    public class Information_Schema_Table {
        public virtual String                     TABLE_CATALOG         { get; set; }
        public virtual String                     TABLE_SCHEMA          { get; set; }
        public virtual String                     TABLE_NAME            { get; set; }
        public virtual String                     TABLE_TYPE            { get; set; }

        public override Boolean Equals(object obj) {
            if (obj == null) {
                return false;
            }
            var val = obj as Information_Schema_Table;
            if (val == null) {
                return false;
            }

            return this.GetHashCode().Equals(val.GetHashCode());
        }

        public override int GetHashCode() {
            return this.TABLE_CATALOG.GetHashCode() ^ this.TABLE_SCHEMA.GetHashCode() ^ 
                this.TABLE_NAME.GetHashCode();
        }
    }

    public class Information_Schema_Column {
        public virtual String                     TABLE_CATALOG         { get; set; }
        public virtual String                     TABLE_SCHEMA          { get; set; }
        public virtual String                     TABLE_NAME            { get; set; }
        public virtual String                     COLUMN_NAME           { get; set; }
        public virtual String                     ORDINAL_POSITION      { get; set; }
        public virtual String                     COLUMN_DEFAULT        { get; set; }
        public virtual String                     IS_NULLABLE           { get; set; }
        public virtual String                     DATA_TYPE             { get; set; }

        public override bool Equals(object obj) {
            if (obj == null ) {
                return false;
            }
            var val = obj as Information_Schema_Column;
            if (val == null) {
                return false;
            }

            return this.GetHashCode().Equals(val.GetHashCode());
        }

        public override int GetHashCode() {
            return this.TABLE_CATALOG.GetHashCode() ^ this.TABLE_SCHEMA.GetHashCode() ^
                this.TABLE_NAME.GetHashCode() ^ this.COLUMN_NAME.GetHashCode();
        }
    }


    public class Information_Schema_TableMap : ClassMap<Information_Schema_Table> {
        public Information_Schema_TableMap() {
            Table("information_schema.tables");
            ReadOnly();
            CompositeId().KeyProperty(x => x.TABLE_CATALOG).KeyProperty(x => x.TABLE_SCHEMA)
                .KeyProperty(x => x.TABLE_NAME);
            Map(x => x.TABLE_CATALOG);
            Map(x => x.TABLE_SCHEMA);
            Map(x => x.TABLE_NAME);
            Map(x => x.TABLE_TYPE);
        }
    }

    public class Information_Schema_ColumnMap : ClassMap<Information_Schema_Column> {
        public Information_Schema_ColumnMap() {
            Table("information_schema.columns");
            ReadOnly();
            CompositeId().KeyProperty(x => x.TABLE_CATALOG).KeyProperty(x => x.TABLE_SCHEMA)
                .KeyProperty(x => x.TABLE_NAME).KeyProperty(x => x.COLUMN_NAME);
            Map(x => x.TABLE_CATALOG);
            Map(x => x.TABLE_SCHEMA);
            Map(x => x.TABLE_NAME);
            Map(x => x.COLUMN_NAME);
            Map(x => x.ORDINAL_POSITION);
            Map(x => x.COLUMN_DEFAULT);
            Map(x => x.IS_NULLABLE);
            Map(x => x.DATA_TYPE);
        }
    }
}
