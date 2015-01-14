using System;
using System.Collections.Generic;

namespace WorkingWithListviewNative
{
	public class DataSource
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public string ImageFilename { get; set; }

		public DataSource ()
		{
		}

		public DataSource (string name, string category, string imageFilename)
		{
			Name = name;
			Category = category;
			ImageFilename = imageFilename;
		}

		public static List<DataSource> GetList (){
			var l = new List<DataSource> ();


			l.Add (new DataSource ("Asparagus","Vegetables","Vegetables"));
			l.Add (new DataSource ("Avocados","Vegetables","Vegetables"));
			l.Add (new DataSource ("Beetroots","Vegetables","Vegetables"));
			l.Add (new DataSource ("Capsicum","Vegetables","Vegetables"));
			l.Add (new DataSource ("Broccoli","Vegetables","Vegetables"));
			l.Add (new DataSource ("Brussel sprouts","Vegetables","Vegetables"));
			l.Add (new DataSource ("Cabbage","Vegetables","Vegetables"));
			l.Add (new DataSource ("Carrots","Vegetables","Vegetables"));
			l.Add (new DataSource ("Cauliflower","Vegetables","Vegetables"));
			l.Add (new DataSource ("Celery","Vegetables","Vegetables"));
			l.Add (new DataSource ("Corn","Vegetables","Vegetables"));
			l.Add (new DataSource ("Cucumbers","Vegetables","Vegetables"));
			l.Add (new DataSource ("Eggplant","Vegetables","Vegetables"));
			l.Add (new DataSource ("Fennel","Vegetables","Vegetables"));
			l.Add (new DataSource ("Garlic","Vegetables","Vegetables"));
			l.Add (new DataSource ("Beans","Vegetables","Vegetables"));
			l.Add (new DataSource ("Peas","Vegetables","Vegetables"));
			l.Add (new DataSource ("Kale","Vegetables","Vegetables"));
			l.Add (new DataSource ("Leeks","Vegetables","Vegetables"));
			l.Add (new DataSource ("Mushrooms","Vegetables","Vegetables"));
			l.Add (new DataSource ("Olives","Vegetables","Vegetables"));
			l.Add (new DataSource ("Onions","Vegetables","Vegetables"));
			l.Add (new DataSource ("Potatoes","Vegetables","Vegetables"));
			l.Add (new DataSource ("Lettuce","Vegetables","Vegetables"));
			l.Add (new DataSource ("Spinach","Vegetables","Vegetables"));
			l.Add (new DataSource ("Squash","Vegetables","Vegetables"));
			l.Add (new DataSource ("Sweet potatoes","Vegetables","Vegetables"));
			l.Add (new DataSource ("Tomatoes","Vegetables","Vegetables"));
			l.Add (new DataSource ("Turnips","Vegetables","Vegetables"));
			l.Add (new DataSource ("Apples","Fruits","Fruits"));
			l.Add (new DataSource ("Apricots","Fruits","Fruits"));
			l.Add (new DataSource ("Bananas","Fruits","Fruits"));
			l.Add (new DataSource ("Blueberries","Fruits","Fruits"));
			l.Add (new DataSource ("Rockmelon","Fruits","Fruits"));
			l.Add (new DataSource ("Figs","Fruits","Fruits"));
			l.Add (new DataSource ("Grapefruit","Fruits","Fruits"));
			l.Add (new DataSource ("Grapes","Fruits","Fruits"));
			l.Add (new DataSource ("Honeydew Melon","Fruits","Fruits"));
			l.Add (new DataSource ("Kiwifruit","Fruits","Fruits"));
			l.Add (new DataSource ("Lemons","Fruits","Fruits"));
			l.Add (new DataSource ("Oranges","Fruits","Fruits"));
			l.Add (new DataSource ("Pears","Fruits","Fruits"));
			l.Add (new DataSource ("Pineapple","Fruits","Fruits"));
			l.Add (new DataSource ("Plums","Fruits","Fruits"));
			l.Add (new DataSource ("Raspberries","Fruits","Fruits"));
			l.Add (new DataSource ("Strawberries","Fruits","Fruits"));
			l.Add (new DataSource ("Watermelon","Fruits","Fruits"));
			l.Add (new DataSource ("Balmain Bugs","Seafood",""));
			l.Add (new DataSource ("Calamari","Seafood",""));
			l.Add (new DataSource ("Cod","Seafood",""));
			l.Add (new DataSource ("Prawns","Seafood",""));
			l.Add (new DataSource ("Lobster","Seafood",""));
			l.Add (new DataSource ("Salmon","Seafood",""));
			l.Add (new DataSource ("Scallops","Seafood",""));
			l.Add (new DataSource ("Shrimp","Seafood",""));
			l.Add (new DataSource ("Tuna","Seafood",""));
			l.Add (new DataSource ("Almonds","Nuts",""));
			l.Add (new DataSource ("Cashews","Nuts",""));
			l.Add (new DataSource ("Peanuts","Nuts",""));
			l.Add (new DataSource ("Walnuts","Nuts",""));
			l.Add (new DataSource ("Black beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Dried peas","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Kidney beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Lentils","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Lima beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Miso","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Soybeans","Beans & Legumes","Legumes"));
			l.Add (new DataSource ("Beef","Meat",""));
			l.Add (new DataSource ("Buffalo","Meat",""));
			l.Add (new DataSource ("Chicken","Meat",""));
			l.Add (new DataSource ("Lamb","Meat",""));
			l.Add (new DataSource ("Cheese","Dairy",""));
			l.Add (new DataSource ("Milk","Dairy",""));
			l.Add (new DataSource ("Eggs","Dairy",""));
			l.Add (new DataSource ("Basil","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Black pepper","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Chili pepper, dried","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Cinnamon","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Cloves","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Cumin","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Dill","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Ginger","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Mustard","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Oregano","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Parsley","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Peppermint","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Rosemary","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Sage","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Thyme","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource ("Turmeric","Herbs & Spices","FlowerBuds"));


			return l;
		}
	}
}

