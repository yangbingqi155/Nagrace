namespace Magelia.WebStore.Client
{

    public class EnhancedCatalogServiceClient : Magelia.WebStore.Client.EnhancedCatalogServiceClientBase, ICatalogServiceClient
    {
        private global::Magelia.WebStore.ServiceQueryable<Attribute> _attributes;
        private global::Magelia.WebStore.ServiceQueryable<AttributeValue> _attributeValues;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedFile> _files;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedBrand> _brands;
        private global::Magelia.WebStore.ServiceQueryable<BaseProduct> _products;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedCatalog> _catalogs;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedCategory> _categories;
        private global::Magelia.WebStore.ServiceQueryable<CategoryProduct> _categoryProducts;
        private global::Magelia.WebStore.ServiceQueryable<CategoryHierarchy> _categoryHierarchies;
        private global::Magelia.WebStore.ServiceQueryable<ProductLink> _productLinks;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedSupplier> _suppliers;
        private global::Magelia.WebStore.ServiceQueryable<BundleItem> _bundleItems;
        private global::Magelia.WebStore.ServiceQueryable<Price> _prices;
        private global::Magelia.WebStore.ServiceQueryable<DiscountDetail> _discountDetails;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedDiscount> _discounts;
        private global::Magelia.WebStore.ServiceQueryable<TaxDetail> _taxDetails;
        private global::Magelia.WebStore.ServiceQueryable<FileTag> _fileTags;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedCarrier> _carriers;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedContinent> _continents;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedCountry> _countries;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedCurrency> _currencies;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedRegion> _regions;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedOrderChannel> _orderChannels;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedSegment> _segments;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedWarehouse> _warehouses;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedStandardProduct> _standardProducts;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedBundleProduct> _bundleProducts;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedVariantProduct> _variantProducts;
        private global::Magelia.WebStore.ServiceQueryable<ExtendedVariableProduct> _variableProducts;
        public EnhancedCatalogServiceClient(System.Lazy<Magelia.WebStore.Client.IStoreServiceClient> storeService, Magelia.WebStore.Client.ICatalogContext catalogContext) :
            base(storeService, catalogContext)
        {
        }
        /// 
        ///            
        /// <summary>Get All attributes values associated to available products.</summary>
        /// 
        ///        
        public virtual global::Magelia.WebStore.ServiceQueryable<Attribute> Attributes
        {
            get
            {
                if ((this._attributes == null))
                {
                    this._attributes = base.CreateQuery<Attribute>("Attributes");
                }
                return this._attributes;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<AttributeValue> AttributeValues
        {
            get
            {
                if ((this._attributeValues == null))
                {
                    this._attributeValues = base.CreateQuery<AttributeValue>("AttributeValues");
                }
                return this._attributeValues;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedFile> Files
        {
            get
            {
                if ((this._files == null))
                {
                    this._files = base.CreateQuery<ExtendedFile>("Files");
                }
                return this._files;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedBrand> Brands
        {
            get
            {
                if ((this._brands == null))
                {
                    this._brands = base.CreateQuery<ExtendedBrand>("Brands");
                }
                return this._brands;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<BaseProduct> Products
        {
            get
            {
                if ((this._products == null))
                {
                    this._products = base.CreateQuery<BaseProduct>("Products");
                }
                return this._products;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedCatalog> Catalogs
        {
            get
            {
                if ((this._catalogs == null))
                {
                    this._catalogs = base.CreateQuery<ExtendedCatalog>("Catalogs");
                }
                return this._catalogs;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedCategory> Categories
        {
            get
            {
                if ((this._categories == null))
                {
                    this._categories = base.CreateQuery<ExtendedCategory>("Categories");
                }
                return this._categories;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<CategoryProduct> CategoryProducts
        {
            get
            {
                if ((this._categoryProducts == null))
                {
                    this._categoryProducts = base.CreateQuery<CategoryProduct>("CategoryProducts");
                }
                return this._categoryProducts;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<CategoryHierarchy> CategoryHierarchies
        {
            get
            {
                if ((this._categoryHierarchies == null))
                {
                    this._categoryHierarchies = base.CreateQuery<CategoryHierarchy>("CategoryHierarchies");
                }
                return this._categoryHierarchies;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ProductLink> ProductLinks
        {
            get
            {
                if ((this._productLinks == null))
                {
                    this._productLinks = base.CreateQuery<ProductLink>("ProductLinks");
                }
                return this._productLinks;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedSupplier> Suppliers
        {
            get
            {
                if ((this._suppliers == null))
                {
                    this._suppliers = base.CreateQuery<ExtendedSupplier>("Suppliers");
                }
                return this._suppliers;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<BundleItem> BundleItems
        {
            get
            {
                if ((this._bundleItems == null))
                {
                    this._bundleItems = base.CreateQuery<BundleItem>("BundleItems");
                }
                return this._bundleItems;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<Price> Prices
        {
            get
            {
                if ((this._prices == null))
                {
                    this._prices = base.CreateQuery<Price>("Prices");
                }
                return this._prices;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<DiscountDetail> DiscountDetails
        {
            get
            {
                if ((this._discountDetails == null))
                {
                    this._discountDetails = base.CreateQuery<DiscountDetail>("DiscountDetails");
                }
                return this._discountDetails;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedDiscount> Discounts
        {
            get
            {
                if ((this._discounts == null))
                {
                    this._discounts = base.CreateQuery<ExtendedDiscount>("Discounts");
                }
                return this._discounts;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<TaxDetail> TaxDetails
        {
            get
            {
                if ((this._taxDetails == null))
                {
                    this._taxDetails = base.CreateQuery<TaxDetail>("TaxDetails");
                }
                return this._taxDetails;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<FileTag> FileTags
        {
            get
            {
                if ((this._fileTags == null))
                {
                    this._fileTags = base.CreateQuery<FileTag>("FileTags");
                }
                return this._fileTags;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedCarrier> Carriers
        {
            get
            {
                if ((this._carriers == null))
                {
                    this._carriers = base.CreateQuery<ExtendedCarrier>("Carriers");
                }
                return this._carriers;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedContinent> Continents
        {
            get
            {
                if ((this._continents == null))
                {
                    this._continents = base.CreateQuery<ExtendedContinent>("Continents");
                }
                return this._continents;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedCountry> Countries
        {
            get
            {
                if ((this._countries == null))
                {
                    this._countries = base.CreateQuery<ExtendedCountry>("Countries");
                }
                return this._countries;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedCurrency> Currencies
        {
            get
            {
                if ((this._currencies == null))
                {
                    this._currencies = base.CreateQuery<ExtendedCurrency>("Currencies");
                }
                return this._currencies;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedRegion> Regions
        {
            get
            {
                if ((this._regions == null))
                {
                    this._regions = base.CreateQuery<ExtendedRegion>("Regions");
                }
                return this._regions;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedOrderChannel> OrderChannels
        {
            get
            {
                if ((this._orderChannels == null))
                {
                    this._orderChannels = base.CreateQuery<ExtendedOrderChannel>("OrderChannels");
                }
                return this._orderChannels;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedSegment> Segments
        {
            get
            {
                if ((this._segments == null))
                {
                    this._segments = base.CreateQuery<ExtendedSegment>("Segments");
                }
                return this._segments;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedWarehouse> Warehouses
        {
            get
            {
                if ((this._warehouses == null))
                {
                    this._warehouses = base.CreateQuery<ExtendedWarehouse>("Warehouses");
                }
                return this._warehouses;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedStandardProduct> StandardProducts
        {
            get
            {
                if ((this._standardProducts == null))
                {
                    this._standardProducts = base.CreateQuery<ExtendedStandardProduct>("StandardProducts");
                }
                return this._standardProducts;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedBundleProduct> BundleProducts
        {
            get
            {
                if ((this._bundleProducts == null))
                {
                    this._bundleProducts = base.CreateQuery<ExtendedBundleProduct>("BundleProducts");
                }
                return this._bundleProducts;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedVariantProduct> VariantProducts
        {
            get
            {
                if ((this._variantProducts == null))
                {
                    this._variantProducts = base.CreateQuery<ExtendedVariantProduct>("VariantProducts");
                }
                return this._variantProducts;
            }
        }
        public virtual global::Magelia.WebStore.ServiceQueryable<ExtendedVariableProduct> VariableProducts
        {
            get
            {
                if ((this._variableProducts == null))
                {
                    this._variableProducts = base.CreateQuery<ExtendedVariableProduct>("VariableProducts");
                }
                return this._variableProducts;
            }
        }
    }
    public interface ICatalogServiceClient : Magelia.WebStore.Client.ICatalogServiceClientBase
    {
        /// 
        ///            
        /// <summary>Get All attributes values associated to available products.</summary>
        /// 
        ///        
        global::Magelia.WebStore.ServiceQueryable<Attribute> Attributes
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<AttributeValue> AttributeValues
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedFile> Files
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedBrand> Brands
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<BaseProduct> Products
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedCatalog> Catalogs
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedCategory> Categories
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<CategoryProduct> CategoryProducts
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<CategoryHierarchy> CategoryHierarchies
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ProductLink> ProductLinks
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedSupplier> Suppliers
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<BundleItem> BundleItems
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<Price> Prices
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<DiscountDetail> DiscountDetails
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedDiscount> Discounts
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<TaxDetail> TaxDetails
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<FileTag> FileTags
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedCarrier> Carriers
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedContinent> Continents
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedCountry> Countries
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedCurrency> Currencies
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedRegion> Regions
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedOrderChannel> OrderChannels
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedSegment> Segments
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedWarehouse> Warehouses
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedStandardProduct> StandardProducts
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedBundleProduct> BundleProducts
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedVariantProduct> VariantProducts
        {
            get;
        }
        global::Magelia.WebStore.ServiceQueryable<ExtendedVariableProduct> VariableProducts
        {
            get;
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The Attribute class
    ///            </summary>
    /// 
    ///        
    public class Attribute
    {
        private System.Guid _attributeId;
        private string _attributeTypeCode;
        private string _productTypeCode;
        private string _code;
        private string _name;
        private int _order;
        private string _description;
        private bool _showInProductList;
        private bool _showInProductDetail;
        private bool _allowFilter;
        private bool _allowSelection;
        private System.Collections.Generic.IEnumerable<AttributeValue> _attributeValues;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attribute id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attribute id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid AttributeId
        {
            get
            {
                return this._attributeId;
            }
            set
            {
                this._attributeId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the type code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The type code.
        ///            </value>
        /// 
        ///        
        public virtual string AttributeTypeCode
        {
            get
            {
                return this._attributeTypeCode;
            }
            set
            {
                this._attributeTypeCode = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product type code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The type code.
        ///            </value>
        /// 
        ///        
        public virtual string ProductTypeCode
        {
            get
            {
                return this._productTypeCode;
            }
            set
            {
                this._productTypeCode = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets the description of this attribute.
        ///            </summary>
        /// 
        ///        
        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        /// 
        ///            
        /// <summary>Indicate if this attribute should be displayed in a product list page.</summary>
        /// 
        ///        
        public virtual bool ShowInProductList
        {
            get
            {
                return this._showInProductList;
            }
            set
            {
                this._showInProductList = value;
            }
        }
        /// 
        ///            
        /// <summary>Indicate if this attribute should be displayed in a product detail page.</summary>
        /// 
        ///        
        public virtual bool ShowInProductDetail
        {
            get
            {
                return this._showInProductDetail;
            }
            set
            {
                this._showInProductDetail = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///                <para>Indicate if this attribute can be used to filter a product list page.</para>
        ///                <para>For example, a color attribute may be present on a product list page to allow filtering products by color.</para>
        ///            </summary>
        /// 
        ///        
        public virtual bool AllowFilter
        {
            get
            {
                return this._allowFilter;
            }
            set
            {
                this._allowFilter = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///                <para>Indicate if this attribute is a variable characteristics or only used for description.</para>
        ///                <para>
        ///                    In most case the value will modify the way a variable product will be displayed. 
        ///                    For example, a Size attribute should be selectable but a Picture attribute should not, it is just an informational attribute. 
        ///                    In this case the product page of a variable product could display a list of all color values, then when a user click on a color, the Picture attribute could be changed
        ///                </para>
        ///            </summary>
        /// 
        ///        
        public virtual bool AllowSelection
        {
            get
            {
                return this._allowSelection;
            }
            set
            {
                this._allowSelection = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Get all the attribute values for this attribute.
        ///            </summary>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<AttributeValue> AttributeValues
        {
            get
            {
                return this._attributeValues;
            }
            set
            {
                this._attributeValues = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The Attribute value
    ///            </summary>
    /// 
    ///        
    public class AttributeValue
    {
        private System.Guid _attributeValueId;
        private System.Guid _productId;
        private System.Guid _attributeId;
        private string _stringValue;
        private string _listCode;
        private string _listValue;
        private System.Nullable<bool> _booleanValue;
        private System.Nullable<int> _intValue;
        private System.Nullable<decimal> _decimalValue;
        private System.Nullable<System.DateTimeOffset> _dateTimeValue;
        private Attribute _attribute;
        private System.Collections.Generic.IEnumerable<File> _files;
        private BaseProduct _product;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attribute value id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attribute id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid AttributeValueId
        {
            get
            {
                return this._attributeValueId;
            }
            set
            {
                this._attributeValueId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attribute id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attribute id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid AttributeId
        {
            get
            {
                return this._attributeId;
            }
            set
            {
                this._attributeId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the string value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The string value.
        ///            </value>
        /// 
        ///        
        public virtual string StringValue
        {
            get
            {
                return this._stringValue;
            }
            set
            {
                this._stringValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Get the code of the list attribute value. 
        ///            </summary>
        /// 
        ///            
        /// <example>
        ///            If we have a product type with a color attribute and if this attribute define 2 values (#FOO for red and #0F0  for green). The ListCode property will contains <value>#F00</value>.
        ///            </example>
        /// 
        ///        
        public virtual string ListCode
        {
            get
            {
                return this._listCode;
            }
            set
            {
                this._listCode = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Get the localized value of this list atttrite value.
        ///            </summary>
        /// 
        ///            
        /// <example>
        ///            If we have a product type with a color attribute and if this attribute define 2 values (#FOO for red and #0F0  for green). The ListValue property will contains <value>red</value> using English culture or <value>rouge</value> using a French culture.
        ///            </example>
        /// 
        ///        
        public virtual string ListValue
        {
            get
            {
                return this._listValue;
            }
            set
            {
                this._listValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the boolean value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The boolean value.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<bool> BooleanValue
        {
            get
            {
                return this._booleanValue;
            }
            set
            {
                this._booleanValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the int value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The int value.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<int> IntValue
        {
            get
            {
                return this._intValue;
            }
            set
            {
                this._intValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the decimal value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The decimal value.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> DecimalValue
        {
            get
            {
                return this._decimalValue;
            }
            set
            {
                this._decimalValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the date time value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The date time value.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> DateTimeValue
        {
            get
            {
                return this._dateTimeValue;
            }
            set
            {
                this._dateTimeValue = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attribute.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attribute.
        ///            </value>
        /// 
        ///        
        public virtual Attribute Attribute
        {
            get
            {
                return this._attribute;
            }
            set
            {
                this._attribute = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the files.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The files.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<File> Files
        {
            get
            {
                return this._files;
            }
            set
            {
                this._files = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product.
        ///            </value>
        /// 
        ///        
        public virtual BaseProduct Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The File class
    ///            </summary>
    /// 
    ///        
    public class File
    {
        private System.Guid _fileId;
        private byte _type;
        private string _name;
        private string _title;
        private string _alternateText;
        private string _description;
        private string _path;
        private System.DateTimeOffset _creationDate;
        private System.Nullable<System.DateTimeOffset> _lastModificationDate;
        private System.Collections.Generic.IEnumerable<AttributeValue> _attributes;
        private System.Collections.Generic.IEnumerable<Brand> _brands;
        private System.Collections.Generic.IEnumerable<Catalog> _catalogs;
        private System.Collections.Generic.IEnumerable<Category> _categories;
        private System.Collections.Generic.IEnumerable<FileTag> _fileTags;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid FileId
        {
            get
            {
                return this._fileId;
            }
            set
            {
                this._fileId = value;
            }
        }
        public virtual byte Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the title.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The title.
        ///            </value>
        /// 
        ///        
        public virtual string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the alternate text.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The alternate text.
        ///            </value>
        /// 
        ///        
        public virtual string AlternateText
        {
            get
            {
                return this._alternateText;
            }
            set
            {
                this._alternateText = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The description.
        ///            </value>
        /// 
        ///        
        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the path.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The path.
        ///            </value>
        /// 
        ///        
        public virtual string Path
        {
            get
            {
                return this._path;
            }
            set
            {
                this._path = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the creation date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The creation date.
        ///            </value>
        /// 
        ///        
        public virtual System.DateTimeOffset CreationDate
        {
            get
            {
                return this._creationDate;
            }
            set
            {
                this._creationDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the last modification date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The last modification date.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> LastModificationDate
        {
            get
            {
                return this._lastModificationDate;
            }
            set
            {
                this._lastModificationDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attributes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attributes.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<AttributeValue> Attributes
        {
            get
            {
                return this._attributes;
            }
            set
            {
                this._attributes = value;
            }
        }
        public virtual System.Collections.Generic.IEnumerable<Brand> Brands
        {
            get
            {
                return this._brands;
            }
            set
            {
                this._brands = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalogs.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalogs.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Catalog> Catalogs
        {
            get
            {
                return this._catalogs;
            }
            set
            {
                this._catalogs = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the categories.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The categories.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Category> Categories
        {
            get
            {
                return this._categories;
            }
            set
            {
                this._categories = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file tags.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file tags.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<FileTag> FileTags
        {
            get
            {
                return this._fileTags;
            }
            set
            {
                this._fileTags = value;
            }
        }
    }
    public class ExtendedFile : File
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Brand class
    ///            </summary>
    /// 
    ///        
    public class Brand
    {
        private System.Guid _brandId;
        private string _code;
        private System.Nullable<System.Guid> _logoFileId;
        private File _logoFile;
        private System.Collections.Generic.IEnumerable<BaseProduct> _products;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the brand id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The brand id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid BrandId
        {
            get
            {
                return this._brandId;
            }
            set
            {
                this._brandId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the logo file id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The logo file id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> LogoFileId
        {
            get
            {
                return this._logoFileId;
            }
            set
            {
                this._logoFileId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the logo file.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The logo file.
        ///            </value>
        /// 
        ///        
        public virtual File LogoFile
        {
            get
            {
                return this._logoFile;
            }
            set
            {
                this._logoFile = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the products.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The products.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<BaseProduct> Products
        {
            get
            {
                return this._products;
            }
            set
            {
                this._products = value;
            }
        }
    }
    public class ExtendedBrand : Brand
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The BaseProduct class 
    ///            </summary>
    /// 
    ///        
    public class BaseProduct
    {
        private System.Guid _productId;
        private System.Guid _catalogId;
        private string _productTypeCode;
        private string _typeName;
        private System.Nullable<System.Guid> _supplierId;
        private System.Nullable<System.Guid> _brandId;
        private System.Nullable<decimal> _weight;
        private System.Nullable<decimal> _height;
        private System.Nullable<decimal> _width;
        private System.Nullable<decimal> _length;
        private bool _isOnline;
        private string _name;
        private string _shortDescription;
        private string _longDescription;
        private string _additionalDescription;
        private System.Collections.Generic.IEnumerable<AttributeValue> _attributeValues;
        private Brand _brand;
        private Catalog _catalog;
        private System.Collections.Generic.IEnumerable<CategoryProduct> _productCategories;
        private System.Collections.Generic.IEnumerable<ProductLink> _productLinkings;
        private System.Collections.Generic.IEnumerable<ProductLink> _productLinks;
        private Supplier _supplier;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalog id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalog id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CatalogId
        {
            get
            {
                return this._catalogId;
            }
            set
            {
                this._catalogId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product type code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The type code.
        ///            </value>
        /// 
        ///        
        public virtual string ProductTypeCode
        {
            get
            {
                return this._productTypeCode;
            }
            set
            {
                this._productTypeCode = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name of the type.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name of the type.
        ///            </value>
        /// 
        ///        
        public virtual string TypeName
        {
            get
            {
                return this._typeName;
            }
            set
            {
                this._typeName = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the supplier id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The supplier id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> SupplierId
        {
            get
            {
                return this._supplierId;
            }
            set
            {
                this._supplierId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the brand id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The brand id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> BrandId
        {
            get
            {
                return this._brandId;
            }
            set
            {
                this._brandId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the weight.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The weight.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the height.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The height.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the width.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The width.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> Width
        {
            get
            {
                return this._width;
            }
            set
            {
                this._width = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the length.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The length.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> Length
        {
            get
            {
                return this._length;
            }
            set
            {
                this._length = value;
            }
        }
        /// 
        ///            
        /// <summary>Indicate whether this product is online or not. It could be usefull for product that you don't want to display on a product list, warranty for example.</summary>
        /// 
        ///        
        public virtual bool IsOnline
        {
            get
            {
                return this._isOnline;
            }
            set
            {
                this._isOnline = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the short description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The short description.
        ///            </value>
        /// 
        ///        
        public virtual string ShortDescription
        {
            get
            {
                return this._shortDescription;
            }
            set
            {
                this._shortDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the long description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The long description.
        ///            </value>
        /// 
        ///        
        public virtual string LongDescription
        {
            get
            {
                return this._longDescription;
            }
            set
            {
                this._longDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the additional description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The additional description.
        ///            </value>
        /// 
        ///        
        public virtual string AdditionalDescription
        {
            get
            {
                return this._additionalDescription;
            }
            set
            {
                this._additionalDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the attribute values.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The attributeValues.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<AttributeValue> AttributeValues
        {
            get
            {
                return this._attributeValues;
            }
            set
            {
                this._attributeValues = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the brand.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The brand.
        ///            </value>
        /// 
        ///        
        public virtual Brand Brand
        {
            get
            {
                return this._brand;
            }
            set
            {
                this._brand = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalog.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalog.
        ///            </value>
        /// 
        ///        
        public virtual Catalog Catalog
        {
            get
            {
                return this._catalog;
            }
            set
            {
                this._catalog = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets the product categories.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product categories.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<CategoryProduct> ProductCategories
        {
            get
            {
                return this._productCategories;
            }
            set
            {
                this._productCategories = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product linkings.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product linkings.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<ProductLink> ProductLinkings
        {
            get
            {
                return this._productLinkings;
            }
            set
            {
                this._productLinkings = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product links.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product links.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<ProductLink> ProductLinks
        {
            get
            {
                return this._productLinks;
            }
            set
            {
                this._productLinks = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the supplier.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The supplier.
        ///            </value>
        /// 
        ///        
        public virtual Supplier Supplier
        {
            get
            {
                return this._supplier;
            }
            set
            {
                this._supplier = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The ReferenceProduct class
    ///            </summary>
    /// 
    ///        
    public class ReferenceProduct : BaseProduct
    {
        private string _sKU;
        private System.Nullable<System.DateTimeOffset> _startDate;
        private System.Nullable<System.DateTimeOffset> _endDate;
        private System.Nullable<System.Guid> _priceIdWithLowerQuantity;
        private System.Collections.Generic.IEnumerable<BundleItem> _bundlingItems;
        private System.Collections.Generic.IEnumerable<Price> _prices;
        private Price _priceWithLowerQuantity;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the SKU.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The SKU.
        ///            </value>
        /// 
        ///        
        public virtual string SKU
        {
            get
            {
                return this._sKU;
            }
            set
            {
                this._sKU = value;
            }
        }
        /// 
        ///            
        /// <summary>Get the start date of the product. Note that only product that StartDate is greater (or null) than the "data update" generation date is available.</summary>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                this._startDate = value;
            }
        }
        /// 
        ///            
        /// <summary>Get the end date of the product. Note that only product that EndDate is lower (or null) than the "data update" generation date is available.</summary>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price id with lower quantity.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price id with lower quantity.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> PriceIdWithLowerQuantity
        {
            get
            {
                return this._priceIdWithLowerQuantity;
            }
            set
            {
                this._priceIdWithLowerQuantity = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundling items.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundling items.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<BundleItem> BundlingItems
        {
            get
            {
                return this._bundlingItems;
            }
            set
            {
                this._bundlingItems = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the prices.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The prices.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Price> Prices
        {
            get
            {
                return this._prices;
            }
            set
            {
                this._prices = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price with lower quantity.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price with lower quantity.
        ///            </value>
        /// 
        ///        
        public virtual Price PriceWithLowerQuantity
        {
            get
            {
                return this._priceWithLowerQuantity;
            }
            set
            {
                this._priceWithLowerQuantity = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The BundleProduct class
    ///            </summary>
    /// 
    ///        
    public class BundleProduct : ReferenceProduct
    {
        private System.Collections.Generic.IEnumerable<BundleItem> _bundleItems;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundle items.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundle items.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<BundleItem> BundleItems
        {
            get
            {
                return this._bundleItems;
            }
            set
            {
                this._bundleItems = value;
            }
        }
    }
    public class ExtendedBundleProduct : BundleProduct
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The StandardProduct class
    ///            </summary>
    /// 
    ///        
    public class StandardProduct : ReferenceProduct
    {
    }
    public class ExtendedStandardProduct : StandardProduct
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The VariantProduct class
    ///            </summary>
    /// 
    ///        
    public class VariantProduct : ReferenceProduct
    {
        private System.Guid _variableProductId;
        private bool _isDefault;
        private int _order;
        private VariableProduct _variableProduct;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the variable product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The variable product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid VariableProductId
        {
            get
            {
                return this._variableProductId;
            }
            set
            {
                this._variableProductId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the is default.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The is default.
        ///            </value>
        /// 
        ///        
        public virtual bool IsDefault
        {
            get
            {
                return this._isDefault;
            }
            set
            {
                this._isDefault = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the variable product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The variable product.
        ///            </value>
        /// 
        ///        
        public virtual VariableProduct VariableProduct
        {
            get
            {
                return this._variableProduct;
            }
            set
            {
                this._variableProduct = value;
            }
        }
    }
    public class ExtendedVariantProduct : VariantProduct
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The VariableProduct class
    ///            </summary>
    /// 
    ///        
    public class VariableProduct : BaseProduct
    {
        private System.Nullable<System.Guid> _defaultVariantProductId;
        private string _code;
        private VariantProduct _defaultVariantProduct;
        private System.Collections.Generic.IEnumerable<VariantProduct> _variantProducts;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the default variant product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The default variant product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> DefaultVariantProductId
        {
            get
            {
                return this._defaultVariantProductId;
            }
            set
            {
                this._defaultVariantProductId = value;
            }
        }
        /// 
        ///            
        /// <summary>Get the uniqueidentifier of this variable.</summary>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the default variant product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The default variant product.
        ///            </value>
        /// 
        ///        
        public virtual VariantProduct DefaultVariantProduct
        {
            get
            {
                return this._defaultVariantProduct;
            }
            set
            {
                this._defaultVariantProduct = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the variant products.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The variant products.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<VariantProduct> VariantProducts
        {
            get
            {
                return this._variantProducts;
            }
            set
            {
                this._variantProducts = value;
            }
        }
    }
    public class ExtendedVariableProduct : VariableProduct
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Catalog class
    ///            </summary>
    /// 
    ///        
    public class Catalog
    {
        private System.Guid _catalogId;
        private string _code;
        private System.Nullable<System.DateTimeOffset> _startDate;
        private System.Nullable<System.DateTimeOffset> _endDate;
        private string _name;
        private string _shortDescription;
        private string _longDescription;
        private System.Collections.Generic.IEnumerable<Category> _categories;
        private System.Collections.Generic.IEnumerable<File> _files;
        private System.Collections.Generic.IEnumerable<BaseProduct> _products;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalog id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalog id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CatalogId
        {
            get
            {
                return this._catalogId;
            }
            set
            {
                this._catalogId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the start date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The start date.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                this._startDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the end date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The end date.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the short description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The short description.
        ///            </value>
        /// 
        ///        
        public virtual string ShortDescription
        {
            get
            {
                return this._shortDescription;
            }
            set
            {
                this._shortDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the long description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The long description.
        ///            </value>
        /// 
        ///        
        public virtual string LongDescription
        {
            get
            {
                return this._longDescription;
            }
            set
            {
                this._longDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the categories.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The categories.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Category> Categories
        {
            get
            {
                return this._categories;
            }
            set
            {
                this._categories = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the files.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The files.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<File> Files
        {
            get
            {
                return this._files;
            }
            set
            {
                this._files = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the products.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The products.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<BaseProduct> Products
        {
            get
            {
                return this._products;
            }
            set
            {
                this._products = value;
            }
        }
    }
    public class ExtendedCatalog : Catalog
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Category class
    ///            </summary>
    /// 
    ///        
    public class Category
    {
        private System.Guid _categoryId;
        private System.Guid _catalogId;
        private string _code;
        private bool _isOnline;
        private string _name;
        private string _shortDescription;
        private string _longDescription;
        private Catalog _catalog;
        private System.Collections.Generic.IEnumerable<CategoryProduct> _categoryProducts;
        private System.Collections.Generic.IEnumerable<CategoryHierarchy> _childCategoryHierarchies;
        private System.Collections.Generic.IEnumerable<File> _files;
        private System.Collections.Generic.IEnumerable<CategoryHierarchy> _parentCategoryHierarchies;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CategoryId
        {
            get
            {
                return this._categoryId;
            }
            set
            {
                this._categoryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalog id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalog id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CatalogId
        {
            get
            {
                return this._catalogId;
            }
            set
            {
                this._catalogId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the is online.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The is online.
        ///            </value>
        /// 
        ///        
        public virtual bool IsOnline
        {
            get
            {
                return this._isOnline;
            }
            set
            {
                this._isOnline = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the short description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The short description.
        ///            </value>
        /// 
        ///        
        public virtual string ShortDescription
        {
            get
            {
                return this._shortDescription;
            }
            set
            {
                this._shortDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the long description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The long description.
        ///            </value>
        /// 
        ///        
        public virtual string LongDescription
        {
            get
            {
                return this._longDescription;
            }
            set
            {
                this._longDescription = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the catalog.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The catalog.
        ///            </value>
        /// 
        ///        
        public virtual Catalog Catalog
        {
            get
            {
                return this._catalog;
            }
            set
            {
                this._catalog = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category products.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category products.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<CategoryProduct> CategoryProducts
        {
            get
            {
                return this._categoryProducts;
            }
            set
            {
                this._categoryProducts = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the child category hierarchies.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The child category hierarchies.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<CategoryHierarchy> ChildCategoryHierarchies
        {
            get
            {
                return this._childCategoryHierarchies;
            }
            set
            {
                this._childCategoryHierarchies = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the files.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The files.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<File> Files
        {
            get
            {
                return this._files;
            }
            set
            {
                this._files = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the parent category hierarchies.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The parent category hierarchies.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<CategoryHierarchy> ParentCategoryHierarchies
        {
            get
            {
                return this._parentCategoryHierarchies;
            }
            set
            {
                this._parentCategoryHierarchies = value;
            }
        }
    }
    public class ExtendedCategory : Category
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The CategoryProduct class
    ///            </summary>
    /// 
    ///        
    public class CategoryProduct
    {
        private System.Guid _categoryId;
        private System.Guid _productId;
        private int _order;
        private Category _category;
        private BaseProduct _product;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CategoryId
        {
            get
            {
                return this._categoryId;
            }
            set
            {
                this._categoryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category.
        ///            </value>
        /// 
        ///        
        public virtual Category Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product.
        ///            </value>
        /// 
        ///        
        public virtual BaseProduct Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The CategoryHierarchy class
    ///            </summary>
    /// 
    ///        
    public class CategoryHierarchy
    {
        private System.Guid _categoryId;
        private System.Guid _parentCategoryId;
        private int _order;
        private Category _category;
        private Category _parentCategory;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CategoryId
        {
            get
            {
                return this._categoryId;
            }
            set
            {
                this._categoryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the parent category id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The parent category id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ParentCategoryId
        {
            get
            {
                return this._parentCategoryId;
            }
            set
            {
                this._parentCategoryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the category.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The category.
        ///            </value>
        /// 
        ///        
        public virtual Category Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the parent category.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The parent category.
        ///            </value>
        /// 
        ///        
        public virtual Category ParentCategory
        {
            get
            {
                return this._parentCategory;
            }
            set
            {
                this._parentCategory = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The ProductLink class
    ///            </summary>
    /// 
    ///        
    public class ProductLink
    {
        private System.Guid _productLinkId;
        private System.Guid _productId;
        private int _order;
        private System.Guid _linkedProductId;
        private BaseProduct _linkedProduct;
        private BaseProduct _product;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product link id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product link id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductLinkId
        {
            get
            {
                return this._productLinkId;
            }
            set
            {
                this._productLinkId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the linked product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The linked product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid LinkedProductId
        {
            get
            {
                return this._linkedProductId;
            }
            set
            {
                this._linkedProductId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the linked product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The linked product.
        ///            </value>
        /// 
        ///        
        public virtual BaseProduct LinkedProduct
        {
            get
            {
                return this._linkedProduct;
            }
            set
            {
                this._linkedProduct = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product.
        ///            </value>
        /// 
        ///        
        public virtual BaseProduct Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The CrossSellingProductLink class
    ///            </summary>
    /// 
    ///        
    public class CrossSellingProductLink : ProductLink
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The UpSellingProductLink class
    ///            </summary>
    /// 
    ///        
    public class UpSellingProductLink : ProductLink
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Supplier class
    ///            </summary>
    /// 
    ///        
    public class Supplier
    {
        private System.Guid _supplierId;
        private string _code;
        private System.Collections.Generic.IEnumerable<BaseProduct> _products;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the supplier id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The supplier id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid SupplierId
        {
            get
            {
                return this._supplierId;
            }
            set
            {
                this._supplierId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the products.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The products.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<BaseProduct> Products
        {
            get
            {
                return this._products;
            }
            set
            {
                this._products = value;
            }
        }
    }
    public class ExtendedSupplier : Supplier
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The BundleItem class
    ///            </summary>
    /// 
    ///        
    public class BundleItem
    {
        private System.Guid _bundleProductId;
        private System.Guid _bundledProductId;
        private int _quantity;
        private int _order;
        private ReferenceProduct _bundledProduct;
        private BundleProduct _bundleProduct;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundle product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundle product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid BundleProductId
        {
            get
            {
                return this._bundleProductId;
            }
            set
            {
                this._bundleProductId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundled product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundled product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid BundledProductId
        {
            get
            {
                return this._bundledProductId;
            }
            set
            {
                this._bundledProductId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the quantity.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The quantity.
        ///            </value>
        /// 
        ///        
        public virtual int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                this._quantity = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order.
        ///            </value>
        /// 
        ///        
        public virtual int Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundled product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundled product.
        ///            </value>
        /// 
        ///        
        public virtual ReferenceProduct BundledProduct
        {
            get
            {
                return this._bundledProduct;
            }
            set
            {
                this._bundledProduct = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the bundle product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The bundle product.
        ///            </value>
        /// 
        ///        
        public virtual BundleProduct BundleProduct
        {
            get
            {
                return this._bundleProduct;
            }
            set
            {
                this._bundleProduct = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The Price class
    ///            </summary>
    /// 
    ///        
    public class Price
    {
        private System.Guid _priceId;
        private System.Guid _productId;
        private int _currencyId;
        private int _quantity;
        private decimal _salePrice;
        private decimal _discount;
        private decimal _discountIncludingTaxes;
        private decimal _taxes;
        private decimal _taxesConsideringDiscount;
        private decimal _salePriceIncludingDiscount;
        private decimal _salePriceIncludingTaxes;
        private decimal _salePriceIncludingDiscountAndTaxes;
        private System.Nullable<decimal> _cutPrice;
        private System.Nullable<decimal> _cutPriceIncludingTaxes;
        private System.Collections.Generic.IEnumerable<DiscountDetail> _discountDetails;
        private ReferenceProduct _product;
        private System.Collections.Generic.IEnumerable<TaxDetail> _taxDetails;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid PriceId
        {
            get
            {
                return this._priceId;
            }
            set
            {
                this._priceId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the currency id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The currency id.
        ///            </value>
        /// 
        ///        
        public virtual int CurrencyId
        {
            get
            {
                return this._currencyId;
            }
            set
            {
                this._currencyId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the quantity.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The quantity.
        ///            </value>
        /// 
        ///        
        public virtual int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                this._quantity = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the sale price.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The sale price.
        ///            </value>
        /// 
        ///        
        public virtual decimal SalePrice
        {
            get
            {
                return this._salePrice;
            }
            set
            {
                this._salePrice = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount.
        ///            </value>
        /// 
        ///        
        public virtual decimal Discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this._discount = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount including taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount including taxes.
        ///            </value>
        /// 
        ///        
        public virtual decimal DiscountIncludingTaxes
        {
            get
            {
                return this._discountIncludingTaxes;
            }
            set
            {
                this._discountIncludingTaxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The taxes.
        ///            </value>
        /// 
        ///        
        public virtual decimal Taxes
        {
            get
            {
                return this._taxes;
            }
            set
            {
                this._taxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the taxes considering discount.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The taxes considering discount.
        ///            </value>
        /// 
        ///        
        public virtual decimal TaxesConsideringDiscount
        {
            get
            {
                return this._taxesConsideringDiscount;
            }
            set
            {
                this._taxesConsideringDiscount = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the sale price including discount.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The sale price including discount.
        ///            </value>
        /// 
        ///        
        public virtual decimal SalePriceIncludingDiscount
        {
            get
            {
                return this._salePriceIncludingDiscount;
            }
            set
            {
                this._salePriceIncludingDiscount = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the sale price including taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The sale price including taxes.
        ///            </value>
        /// 
        ///        
        public virtual decimal SalePriceIncludingTaxes
        {
            get
            {
                return this._salePriceIncludingTaxes;
            }
            set
            {
                this._salePriceIncludingTaxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the sale price including discount and taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The sale price including discount and taxes.
        ///            </value>
        /// 
        ///        
        public virtual decimal SalePriceIncludingDiscountAndTaxes
        {
            get
            {
                return this._salePriceIncludingDiscountAndTaxes;
            }
            set
            {
                this._salePriceIncludingDiscountAndTaxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the cut price.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The cut price.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> CutPrice
        {
            get
            {
                return this._cutPrice;
            }
            set
            {
                this._cutPrice = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the cut price including taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The cut price including taxes.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<decimal> CutPriceIncludingTaxes
        {
            get
            {
                return this._cutPriceIncludingTaxes;
            }
            set
            {
                this._cutPriceIncludingTaxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount details.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount details.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<DiscountDetail> DiscountDetails
        {
            get
            {
                return this._discountDetails;
            }
            set
            {
                this._discountDetails = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the product.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The product.
        ///            </value>
        /// 
        ///        
        public virtual ReferenceProduct Product
        {
            get
            {
                return this._product;
            }
            set
            {
                this._product = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the tax details.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The tax details.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<TaxDetail> TaxDetails
        {
            get
            {
                return this._taxDetails;
            }
            set
            {
                this._taxDetails = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The DiscountDetail class
    ///            </summary>
    /// 
    ///        
    public class DiscountDetail
    {
        private System.Guid _discountDetailId;
        private System.Guid _discountId;
        private System.Guid _priceId;
        private decimal _value;
        private decimal _valueIncludingTaxes;
        private Discount _discount;
        private Price _price;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount detail id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount detail id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid DiscountDetailId
        {
            get
            {
                return this._discountDetailId;
            }
            set
            {
                this._discountDetailId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid DiscountId
        {
            get
            {
                return this._discountId;
            }
            set
            {
                this._discountId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid PriceId
        {
            get
            {
                return this._priceId;
            }
            set
            {
                this._priceId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The value.
        ///            </value>
        /// 
        ///        
        public virtual decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the value including taxes.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The value including taxes.
        ///            </value>
        /// 
        ///        
        public virtual decimal ValueIncludingTaxes
        {
            get
            {
                return this._valueIncludingTaxes;
            }
            set
            {
                this._valueIncludingTaxes = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount.
        ///            </value>
        /// 
        ///        
        public virtual Discount Discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this._discount = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price.
        ///            </value>
        /// 
        ///        
        public virtual Price Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The Dicount class
    ///            </summary>
    /// 
    ///        
    public class Discount
    {
        private System.Guid _discountId;
        private string _code;
        private string _externalCode;
        private string _name;
        private string _description;
        private bool _isActive;
        private System.Nullable<System.DateTimeOffset> _startDate;
        private System.Nullable<System.DateTimeOffset> _endDate;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the discount id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The discount id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid DiscountId
        {
            get
            {
                return this._discountId;
            }
            set
            {
                this._discountId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the external code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The external code.
        ///            </value>
        /// 
        ///        
        public virtual string ExternalCode
        {
            get
            {
                return this._externalCode;
            }
            set
            {
                this._externalCode = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The description.
        ///            </value>
        /// 
        ///        
        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the is active.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The is active.
        ///            </value>
        /// 
        ///        
        public virtual bool IsActive
        {
            get
            {
                return this._isActive;
            }
            set
            {
                this._isActive = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the start date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The start date.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                this._startDate = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the end date.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The end date.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.DateTimeOffset> EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
    }
    public class ExtendedDiscount : Discount
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The TaxDetail class
    ///            </summary>
    /// 
    ///        
    public class TaxDetail
    {
        private System.Guid _taxDetailId;
        private System.Guid _priceId;
        private string _code;
        private string _name;
        private decimal _value;
        private Price _price;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the tax detail id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The tax detail id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid TaxDetailId
        {
            get
            {
                return this._taxDetailId;
            }
            set
            {
                this._taxDetailId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid PriceId
        {
            get
            {
                return this._priceId;
            }
            set
            {
                this._priceId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the value.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The value.
        ///            </value>
        /// 
        ///        
        public virtual decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the price.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The price.
        ///            </value>
        /// 
        ///        
        public virtual Price Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The FileTag class
    ///            </summary>
    /// 
    ///        
    public class FileTag
    {
        private System.Guid _fileTagId;
        private System.Guid _fileId;
        private string _tag;
        private File _file;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file tag id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file tag id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid FileTagId
        {
            get
            {
                return this._fileTagId;
            }
            set
            {
                this._fileTagId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid FileId
        {
            get
            {
                return this._fileId;
            }
            set
            {
                this._fileId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the tag.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The tag.
        ///            </value>
        /// 
        ///        
        public virtual string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file.
        ///            </value>
        /// 
        ///        
        public virtual File File
        {
            get
            {
                return this._file;
            }
            set
            {
                this._file = value;
            }
        }
    }
    /// 
    ///            
    /// <summary>
    ///            The Carrier class
    ///            </summary>
    /// 
    ///        
    public class Carrier
    {
        private System.Guid _carrierId;
        private System.Nullable<System.Guid> _fileId;
        private string _code;
        private string _name;
        private File _file;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the carrier id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The carrier id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid CarrierId
        {
            get
            {
                return this._carrierId;
            }
            set
            {
                this._carrierId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<System.Guid> FileId
        {
            get
            {
                return this._fileId;
            }
            set
            {
                this._fileId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the file.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The file.
        ///            </value>
        /// 
        ///        
        public virtual File File
        {
            get
            {
                return this._file;
            }
            set
            {
                this._file = value;
            }
        }
    }
    public class ExtendedCarrier : Carrier
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Continent class
    ///            </summary>
    /// 
    ///        
    public class Continent
    {
        private byte _continentId;
        private string _code;
        private string _name;
        private System.Collections.Generic.IEnumerable<Country> _countries;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the continent id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The continent id.
        ///            </value>
        /// 
        ///        
        public virtual byte ContinentId
        {
            get
            {
                return this._continentId;
            }
            set
            {
                this._continentId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the countries.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The countries.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Country> Countries
        {
            get
            {
                return this._countries;
            }
            set
            {
                this._countries = value;
            }
        }
    }
    public class ExtendedContinent : Continent
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Country class
    ///            </summary>
    /// 
    ///        
    public class Country
    {
        private int _countryId;
        private byte _continentId;
        private System.Nullable<int> _currencyId;
        private string _name;
        private string _iSO2Code;
        private string _iSO3Code;
        private Continent _continent;
        private Currency _currency;
        private System.Collections.Generic.IEnumerable<Region> _regions;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the country id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The country id.
        ///            </value>
        /// 
        ///        
        public virtual int CountryId
        {
            get
            {
                return this._countryId;
            }
            set
            {
                this._countryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the continent id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The continent id.
        ///            </value>
        /// 
        ///        
        public virtual byte ContinentId
        {
            get
            {
                return this._continentId;
            }
            set
            {
                this._continentId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the currency id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The currency id.
        ///            </value>
        /// 
        ///        
        public virtual System.Nullable<int> CurrencyId
        {
            get
            {
                return this._currencyId;
            }
            set
            {
                this._currencyId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the IS o2 code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The IS o2 code.
        ///            </value>
        /// 
        ///        
        public virtual string ISO2Code
        {
            get
            {
                return this._iSO2Code;
            }
            set
            {
                this._iSO2Code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the IS o3 code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The IS o3 code.
        ///            </value>
        /// 
        ///        
        public virtual string ISO3Code
        {
            get
            {
                return this._iSO3Code;
            }
            set
            {
                this._iSO3Code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the continent.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The continent.
        ///            </value>
        /// 
        ///        
        public virtual Continent Continent
        {
            get
            {
                return this._continent;
            }
            set
            {
                this._continent = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the currency.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The currency.
        ///            </value>
        /// 
        ///        
        public virtual Currency Currency
        {
            get
            {
                return this._currency;
            }
            set
            {
                this._currency = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the regions.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The regions.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Region> Regions
        {
            get
            {
                return this._regions;
            }
            set
            {
                this._regions = value;
            }
        }
    }
    public class ExtendedCountry : Country
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Currency class
    ///            </summary>
    /// 
    ///        
    public class Currency
    {
        private int _currencyId;
        private string _code;
        private string _name;
        private string _symbol;
        private short _precision;
        private System.Collections.Generic.IEnumerable<Country> _countries;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the currency id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The currency id.
        ///            </value>
        /// 
        ///        
        public virtual int CurrencyId
        {
            get
            {
                return this._currencyId;
            }
            set
            {
                this._currencyId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the symbol.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The symbol.
        ///            </value>
        /// 
        ///        
        public virtual string Symbol
        {
            get
            {
                return this._symbol;
            }
            set
            {
                this._symbol = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the precision.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The precision.
        ///            </value>
        /// 
        ///        
        public virtual short Precision
        {
            get
            {
                return this._precision;
            }
            set
            {
                this._precision = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the countries.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The countries.
        ///            </value>
        /// 
        ///        
        public virtual System.Collections.Generic.IEnumerable<Country> Countries
        {
            get
            {
                return this._countries;
            }
            set
            {
                this._countries = value;
            }
        }
    }
    public class ExtendedCurrency : Currency
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Region class
    ///            </summary>
    /// 
    ///        
    public class Region
    {
        private System.Guid _regionId;
        private int _countryId;
        private string _code;
        private string _name;
        private Country _country;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the region id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The region id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid RegionId
        {
            get
            {
                return this._regionId;
            }
            set
            {
                this._regionId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the country id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The country id.
        ///            </value>
        /// 
        ///        
        public virtual int CountryId
        {
            get
            {
                return this._countryId;
            }
            set
            {
                this._countryId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the country.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The country.
        ///            </value>
        /// 
        ///        
        public virtual Country Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }
    }
    public class ExtendedRegion : Region
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The OrderChannel class
    ///            </summary>
    /// 
    ///        
    public class OrderChannel
    {
        private System.Guid _orderChannelId;
        private string _code;
        private string _name;
        private string _description;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the order channel id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The order channel id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid OrderChannelId
        {
            get
            {
                return this._orderChannelId;
            }
            set
            {
                this._orderChannelId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The description.
        ///            </value>
        /// 
        ///        
        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
    }
    public class ExtendedOrderChannel : OrderChannel
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Segment class
    ///            </summary>
    /// 
    ///        
    public class Segment
    {
        private System.Guid _segmentId;
        private string _code;
        private string _description;
        private string _externalCode;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the segment id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The segment id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid SegmentId
        {
            get
            {
                return this._segmentId;
            }
            set
            {
                this._segmentId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the description.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The description.
        ///            </value>
        /// 
        ///        
        public virtual string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the externalCode.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The externalCode.
        ///            </value>
        /// 
        ///        
        public virtual string ExternalCode
        {
            get
            {
                return this._externalCode;
            }
            set
            {
                this._externalCode = value;
            }
        }
    }
    public class ExtendedSegment : Segment
    {
    }
    /// 
    ///            
    /// <summary>
    ///            The Warehouse class
    ///            </summary>
    /// 
    ///        
    public class Warehouse
    {
        private System.Guid _warehouseId;
        private string _code;
        private string _name;
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the warehouse id.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The warehouse id.
        ///            </value>
        /// 
        ///        
        public virtual System.Guid WarehouseId
        {
            get
            {
                return this._warehouseId;
            }
            set
            {
                this._warehouseId = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the code.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The code.
        ///            </value>
        /// 
        ///        
        public virtual string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }
        /// 
        ///            
        /// <summary>
        ///            Gets or sets the name.
        ///            </summary>
        /// 
        ///            
        /// <value>
        ///            The name.
        ///            </value>
        /// 
        ///        
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
    }
    public class ExtendedWarehouse : Warehouse
    {
    }
}
