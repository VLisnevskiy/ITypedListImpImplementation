using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public class DBRepository : DbContext
    {
        public DBRepository()
            : base(
                new SqlConnection(
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dropbox\Projects\Useful\ITypedListImpImplementation\ITypedListImpImplementation\DataBase\LocalDB.mdf;Integrated Security=True"),
                false)
        {
            Database.SetInitializer<DBRepository>(new DBRepositoryDataInitializer());
        }

        public virtual DbSet<ProjectItem> ProjectItems { get; set; }

        public virtual DbSet<CustomFieldSetup> CustomFieldSetups { get; set; }

        public virtual DbSet<CustomFieldValue> CustomFieldValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class DBRepositoryDataInitializer : DropCreateDatabaseIfModelChanges<DBRepository>
    {
        protected override void Seed(DBRepository context)
        {
            List<CustomFieldSetup> CustomFields = new List<CustomFieldSetup>();
            CustomFieldSetup customFieldSetup1 = new CustomFieldSetup();
            customFieldSetup1.FieldName = "CustomField1";
            customFieldSetup1.Caption = "CustomField1";
            customFieldSetup1.IsNullable = true;
            customFieldSetup1.TypeName = typeof(string).FullName;
            CustomFields.Add(customFieldSetup1);

            CustomFieldSetup customFieldSetup2 = new CustomFieldSetup();
            customFieldSetup2.FieldName = "CustomField2";
            customFieldSetup2.Caption = "CustomField2";
            customFieldSetup2.IsNullable = true;
            customFieldSetup2.TypeName = typeof(string).FullName;
            CustomFields.Add(customFieldSetup2);

            CustomFields.ForEach(cf => context.CustomFieldSetups.Add(cf));
            context.SaveChanges();

            List<ProjectItem> projectItems = new List<ProjectItem>();
            ProjectItem projectItem = new ProjectItem();
            projectItem.Name = "New 1";
            projectItem.CustomFieldValues = new List<CustomFieldValue>();

            context.ProjectItems.Add(projectItem);
            context.SaveChanges();

            CustomFieldValue customFieldValue1 = new CustomFieldValue();
            customFieldValue1.FieldSetupId = customFieldSetup1.Id;
            customFieldValue1.FieldName = customFieldSetup1.FieldName;
            customFieldValue1.Value = "Text One";
            customFieldValue1.ProjectItemId = projectItem.Id;
            projectItem.CustomFieldValues.Add(customFieldValue1);

            context.CustomFieldValues.Add(customFieldValue1);
            context.SaveChanges();

            

            CustomFieldValue customFieldValue2 = new CustomFieldValue();
            customFieldValue2.FieldSetupId = customFieldSetup2.Id;
            customFieldValue2.FieldName = customFieldSetup2.FieldName;
            customFieldValue2.Value = "Text Two";
            customFieldValue2.ProjectItemId = projectItem.Id;
            projectItem.CustomFieldValues.Add(customFieldValue2);

            context.CustomFieldValues.Add(customFieldValue2);
            context.SaveChanges();

            

            context.Entry(projectItem).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
