using System;
using System.Collections.Generic;

namespace WorkingWithListviewNative
{
	public class DataSource2
	{
		public string Name { get; set; }
		public string Category { get; set; }
		public string ImageFilename { get; set; }

		public DataSource2 ()
		{
		}

		public DataSource2 (string name, string category, string imageFilename)
		{
			Name = name;
			Category = category;
			ImageFilename = imageFilename;
		}

		public static List<DataSource2> GetList (){
			var l = new List<DataSource2> ();


			l.Add (new DataSource2 ("Asparagus","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Avocados","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Beetroots","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Capsicum","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Broccoli","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Brussel sprouts","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Cabbage","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Carrots","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Cauliflower","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Celery","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Corn","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Cucumbers","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Eggplant","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Fennel","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Garlic","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Beans","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Peas","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Kale","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Leeks","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Mushrooms","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Olives","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Onions","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Potatoes","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Lettuce","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Spinach","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Squash","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Sweet potatoes","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Tomatoes","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Turnips","Vegetables","Vegetables"));
			l.Add (new DataSource2 ("Apples","Fruits","Fruits"));
			l.Add (new DataSource2 ("Apricots","Fruits","Fruits"));
			l.Add (new DataSource2 ("Bananas","Fruits","Fruits"));
			l.Add (new DataSource2 ("Blueberries","Fruits","Fruits"));
			l.Add (new DataSource2 ("Rockmelon","Fruits","Fruits"));
			l.Add (new DataSource2 ("Figs","Fruits","Fruits"));
			l.Add (new DataSource2 ("Grapefruit","Fruits","Fruits"));
			l.Add (new DataSource2 ("Grapes","Fruits","Fruits"));
			l.Add (new DataSource2 ("Honeydew Melon","Fruits","Fruits"));
			l.Add (new DataSource2 ("Kiwifruit","Fruits","Fruits"));
			l.Add (new DataSource2 ("Lemons","Fruits","Fruits"));
			l.Add (new DataSource2 ("Oranges","Fruits","Fruits"));
			l.Add (new DataSource2 ("Pears","Fruits","Fruits"));
			l.Add (new DataSource2 ("Pineapple","Fruits","Fruits"));
			l.Add (new DataSource2 ("Plums","Fruits","Fruits"));
			l.Add (new DataSource2 ("Raspberries","Fruits","Fruits"));
			l.Add (new DataSource2 ("Strawberries","Fruits","Fruits"));
			l.Add (new DataSource2 ("Watermelon","Fruits","Fruits"));
			l.Add (new DataSource2 ("Balmain Bugs","Seafood",""));
			l.Add (new DataSource2 ("Calamari","Seafood",""));
			l.Add (new DataSource2 ("Cod","Seafood",""));
			l.Add (new DataSource2 ("Prawns","Seafood",""));
			l.Add (new DataSource2 ("Lobster","Seafood",""));
			l.Add (new DataSource2 ("Salmon","Seafood",""));
			l.Add (new DataSource2 ("Scallops","Seafood",""));
			l.Add (new DataSource2 ("Shrimp","Seafood",""));
			l.Add (new DataSource2 ("Tuna","Seafood",""));
			l.Add (new DataSource2 ("Almonds","Nuts",""));
			l.Add (new DataSource2 ("Cashews","Nuts",""));
			l.Add (new DataSource2 ("Peanuts","Nuts",""));
			l.Add (new DataSource2 ("Walnuts","Nuts",""));
			l.Add (new DataSource2 ("Black beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Dried peas","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Kidney beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Lentils","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Lima beans","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Miso","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Soybeans","Beans & Legumes","Legumes"));
			l.Add (new DataSource2 ("Beef","Meat",""));
			l.Add (new DataSource2 ("Buffalo","Meat",""));
			l.Add (new DataSource2 ("Chicken","Meat",""));
			l.Add (new DataSource2 ("Lamb","Meat",""));
			l.Add (new DataSource2 ("Cheese","Dairy",""));
			l.Add (new DataSource2 ("Milk","Dairy",""));
			l.Add (new DataSource2 ("Eggs","Dairy",""));
			l.Add (new DataSource2 ("Basil","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Black pepper","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Chili pepper, dried","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Cinnamon","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Cloves","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Cumin","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Dill","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Ginger","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Mustard","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Oregano","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Parsley","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Peppermint","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Rosemary","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Sage","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Thyme","Herbs & Spices","FlowerBuds"));
			l.Add (new DataSource2 ("Turmeric","Herbs & Spices","FlowerBuds"));


			return l;
		}
	}
}

