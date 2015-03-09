using System;
using System.Collections.Generic;
using System.Reflection;

namespace ITypedListImpImplementation.Entity
{
    public static class ColumnsManager
    {
        private static Dictionary<Type, List<XmlColumn>> map = new Dictionary<Type, List<XmlColumn>>();
        public static List<CustomFieldSetup> CustomFields = new List<CustomFieldSetup>();

        static ColumnsManager()
        {
            CustomFieldSetup customFieldSetup = new CustomFieldSetup();
            customFieldSetup.FieldName = "LookupF1";
            customFieldSetup.Caption = "LookupF1";
            customFieldSetup.IsNullable = true;
            customFieldSetup.TypeName = typeof(string).FullName;
            CustomFields.Add(customFieldSetup);

            customFieldSetup = new CustomFieldSetup();
            customFieldSetup.FieldName = "LookupF2";
            customFieldSetup.Caption = "LookupF2";
            customFieldSetup.IsNullable = true;
            customFieldSetup.TypeName = typeof(string).FullName;
            CustomFields.Add(customFieldSetup);
        }

        public static List<XmlColumn> GetColumns<TSource>()
        {
            if (!map.ContainsKey(typeof (TSource)))
            {
                map.Add(typeof(TSource), GatherColumns<TSource>());
            }

            return map[typeof (TSource)];
        }

        private static List<XmlColumn> GatherColumns<TSource>()
        {
            List<XmlColumn> columns = new List<XmlColumn>();
            
            foreach (PropertyInfo property in typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ColumnDescriptionAttribute attribute = property.GetAttribute<ColumnDescriptionAttribute>(false);
                if (null != attribute)
                {
                    columns.Add(new XmlColumn(property.Name, attribute));
                }
            }

            foreach (CustomFieldSetup lookup in CustomFields)
            {
                columns.Add(new XmlColumn(lookup));
            }

            return columns;
        }
    }
}