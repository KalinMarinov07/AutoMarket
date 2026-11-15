namespace AutoMarket.Common
{
    public static class ValidationConstants
    {
        public static class Brand
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 25;
        }

        public static class Model
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 75;
        }

        public static class CarListing
        {
            public const string PriceColumnType = "DECIMAL(9, 2)";

            public const int DescriptionMaxLength = 1000;
        }
    }
}
