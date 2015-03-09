using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ITypedListImpImplementation.Entity
{
    public class ProjectItemCustomFieldPropertyDescriptor : PropertyDescriptor
    {
        private CustomFieldSetup customField;

        public ProjectItemCustomFieldPropertyDescriptor(CustomFieldSetup customField) : base(customField.FieldName, null)
        {
            this.customField = customField;
        }

        public override Type ComponentType
        {
            get { return typeof(ProjectItem); }
        }

        public override bool IsReadOnly
        {
            get { return customField.ReadOnly; }
        }

        public override Type PropertyType
        {
            get
            {
                if (string.IsNullOrEmpty(customField.TypeName))
                {
                    return typeof (string);
                }

                return Type.GetType(customField.TypeName, false, true);
            }
        }

        public override string Description
        {
            get { return customField.Description; }
        }

        public override string DisplayName
        {
            get { return customField.Caption; }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            ICustomFieldsValue customFieldsValue = component as ICustomFieldsValue;
            if (null == customFieldsValue)
            {
                return null;
            }

            CustomFieldValue customFieldValue = customFieldsValue.CustomFieldValues.FirstOrDefault(l => l.FieldName == Name);
            if (null == customFieldValue)
            {
                return null;
            }

            return customFieldValue.Value.Convert(PropertyType);
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException("ResetValue(...) method not implemented!");
        }

        public override void SetValue(object component, object value)
        {
            ICustomFieldsValue fieldsValue = component as ICustomFieldsValue;
            if (null == fieldsValue)
            {
                return;
            }

            CustomFieldValue fieldValue = fieldsValue.CustomFieldValues.FirstOrDefault(l => l.FieldName == Name);
            if (null == fieldValue)
            {
                fieldValue = new CustomFieldValue();
                fieldValue.FieldName = customField.FieldName;
                //fieldValue.FieldSetupId = customField.Id;
                fieldValue.ProjectItemId = ((ProjectItem) component).Id;

                fieldsValue.CustomFieldValues.Add(fieldValue);
            }

            fieldValue.Value = null != value ? value.ToString() : null;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
