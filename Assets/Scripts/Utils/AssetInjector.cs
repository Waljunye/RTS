using System;
using System.Reflection;
public static class AssetInjector
{
    private static Type _injectAssetAttributteType = typeof(InjectAssetAttribute);
    public static T inject<T>(this AssetsContext context, T target)
    {
        Type targetType = target.GetType();
        var allFields = targetType.GetFields(
            BindingFlags.NonPublic | 
            BindingFlags.Public | 
            BindingFlags.Instance);

        for(int i = 0; i < allFields.Length; i++)
        {
            FieldInfo fieldInfo = allFields[i];
            var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributteType) as InjectAssetAttribute;
            if (injectAssetAttribute == null)
            {
                continue;
            }
            var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
            fieldInfo.SetValue(target, objectToInject);
        }
        return target;
    }
}
