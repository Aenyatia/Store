namespace Store.Web.Extensions
{
	public static class ObjectExtensions
	{
		public static object GetPropertyValue(this object source, string propertyName)
		{
			if (source == null)
				return null;

			var type = source.GetType();
			var propertyInfo = type.GetProperty(propertyName);

			return propertyInfo?.GetValue(source, null);
		}

		public static T GetPropertyValue<T>(this object source, string propertyName)
			=> (T)source.GetPropertyValue(propertyName);
	}
}
