using System;
namespace WebAPI.Model
{
	public class Product
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
		public string ProductCategory { get; set; }
		public string ProductPrice { get; set; }

		public Product()
		{
		}
	}
}

