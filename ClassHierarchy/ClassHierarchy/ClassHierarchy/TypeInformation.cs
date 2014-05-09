using System;
using System.Reflection;

namespace ClassHierarchy
{
    class TypeInformation
    {
        bool isBaseGenericType;
        Type baseGenericTypeDef;

        public TypeInformation(Type type)
        {
            this.Type = type;
            TypeInfo typeInfo = type.GetTypeInfo();

            this.BaseType = typeInfo.BaseType;

            if (this.BaseType != null)
            {
                TypeInfo baseTypeInfo = this.BaseType.GetTypeInfo();
                this.isBaseGenericType = baseTypeInfo.IsGenericType;

                if (this.isBaseGenericType)
                {
                    this.baseGenericTypeDef =
                        baseTypeInfo.GetGenericTypeDefinition();
                }
            }
        }

        public Type Type { private set; get; }
        public Type BaseType { private set; get; }

        public bool IsDerivedDirectlyFrom(Type parentType)
        {
            if (this.BaseType != null && this.isBaseGenericType)
            {
                if (this.baseGenericTypeDef == parentType)
                {
                    return true;
                }
            }
            else if (this.BaseType == parentType)
            {
                return true;
            }
            return false;
        }
    }
}
