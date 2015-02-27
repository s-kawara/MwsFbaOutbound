using FBAOutboundServiceMWS;
using FBAOutboundServiceMWS.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace MwsFbaOutbound
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get Fulfillment Preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFulfillmentPreview_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetFulfillmentPreviewRequest request = new GetFulfillmentPreviewRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;

            Address address = new Address();
            address.Name = "Set FullName";
            address.Line1 = "Set Address 1";
            address.Line2 = "Set Address 2";
            address.Line3 = "Set Address 3";
            address.DistrictOrCounty = "Set Prefecture";
            address.City = "Set City";
            address.StateOrProvinceCode = "Set Prefecture";
            address.CountryCode = "Set Country Code";
            address.PhoneNumber = "Set Phone Number";
            address.PostalCode = "Set PostalCode";
            request.Address = address;

            GetFulfillmentPreviewItem item = new GetFulfillmentPreviewItem();
            item.SellerSKU = "Set Seller SKU";
            item.SellerFulfillmentOrderItemId = "Set Quantity";
            item.Quantity = 1;
            GetFulfillmentPreviewItemList itemList = new GetFulfillmentPreviewItemList();
            itemList.member.Add(item);
            request.Items = itemList;

            // 処理実行
            GetFulfillmentPreviewResponse response = client.GetFulfillmentPreview(request);
            if (response.IsSetGetFulfillmentPreviewResult())
            {
                GetFulfillmentPreviewResult getFulfillmentPreviewResult = response.GetFulfillmentPreviewResult;
                if (getFulfillmentPreviewResult.IsSetFulfillmentPreviews())
                {
                    FulfillmentPreviewList fulfillmentPreviews = getFulfillmentPreviewResult.FulfillmentPreviews;
                    List<FulfillmentPreview> memberList = fulfillmentPreviews.member;
                    foreach (FulfillmentPreview member in memberList)
                    {
                        // 取得値表示
                        if (member.IsSetEstimatedShippingWeight())
                        {
                            Weight estimatedShippingWeight = member.EstimatedShippingWeight;
                            strbuff += "Unit:" + estimatedShippingWeight.Unit + " Vakye:" + estimatedShippingWeight.Value;
                        }
                    }
                    txtGetFulfillmentPreview.Text = strbuff;
                }
            }

        }

        /// <summary>
        /// Create Fulfillment Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFulfillmentOrder_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            CreateFulfillmentOrderRequest request = new CreateFulfillmentOrderRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.SellerFulfillmentOrderId = "Order_001";
            request.DisplayableOrderId = "Order_001";
            request.DisplayableOrderDateTime = DateTime.Now;
            request.ShippingSpeedCategory = "";

            Address address = new Address();
            address.Name = "Set FullName";
            address.Line1 = "Set Address 1";
            address.Line2 = "Set Address 2";
            address.Line3 = "Set Address 3";
            address.DistrictOrCounty = "Set Prefecture";
            address.City = "Set City";
            address.StateOrProvinceCode = "Set Prefecture";
            address.CountryCode = "Set Country Code";
            address.PhoneNumber = "Set Phone Number";
            address.PostalCode = "Set PostalCode";
            request.DestinationAddress = address;
            request.ShippingSpeedCategory = "Standard";
            CreateFulfillmentOrderItem item = new CreateFulfillmentOrderItem();
            item.SellerSKU = "Set Seller SKU";
            item.SellerFulfillmentOrderItemId = "Set Quantity";
            item.Quantity = 1;
            CreateFulfillmentOrderItemList itemList = new CreateFulfillmentOrderItemList();
            itemList.member.Add(item);
            request.Items = itemList;

            CreateFulfillmentOrderResponse response = client.CreateFulfillmentOrder(request);
        }

        /// <summary>
        /// Update Fulfillment Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateFulfillmentOrder_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            UpdateFulfillmentOrderRequest request = new UpdateFulfillmentOrderRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.SellerFulfillmentOrderId = "Set Order No";
            request.DisplayableOrderId = "Set Order No";
            request.DisplayableOrderDateTime = DateTime.Now;
            request.ShippingSpeedCategory = "Set Category";

            Address address = new Address();
            address.Name = "Set FullName";
            address.Line1 = "Set Address 1";
            address.Line2 = "Set Address 2";
            address.Line3 = "Set Address 3";
            address.DistrictOrCounty = "Set Prefecture";
            address.City = "Set City";
            address.StateOrProvinceCode = "Set Prefecture";
            address.CountryCode = "Set Country Code";
            address.PhoneNumber = "Set Phone Number";
            address.PostalCode = "Set PostalCode";
            request.DestinationAddress = address;
            request.ShippingSpeedCategory = "Standard";
            UpdateFulfillmentOrderItem item = new UpdateFulfillmentOrderItem();
            item.SellerSKU = "Set Seller SKU";
            item.SellerFulfillmentOrderItemId = "Set Quantity";
            item.Quantity = 1;
            UpdateFulfillmentOrderItemList itemList = new UpdateFulfillmentOrderItemList();
            itemList.member.Add(item);
            request.Items = itemList;

            UpdateFulfillmentOrderResponse response = client.UpdateFulfillmentOrder(request);
        }

        /// <summary>
        /// Get Fulfillment Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetFulfillmentOrder_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetFulfillmentOrderRequest request = new GetFulfillmentOrderRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.SellerFulfillmentOrderId = "Set Order Id";

            GetFulfillmentOrderResponse response = client.GetFulfillmentOrder(request);
            if (response.IsSetGetFulfillmentOrderResult())
            {
                GetFulfillmentOrderResult getFulfillmentOrderResult = response.GetFulfillmentOrderResult;
                if (getFulfillmentOrderResult.IsSetFulfillmentOrder())
                {
                    FulfillmentOrder fulfillmentOrder = getFulfillmentOrderResult.FulfillmentOrder;
                    if (fulfillmentOrder.IsSetSellerFulfillmentOrderId())
                    {
                        strbuff += "Order ID:" + fulfillmentOrder.SellerFulfillmentOrderId;
                    }
                }
            }
            txtGetFulfillmentOrder.Text = strbuff;
        }

        /// <summary>
        /// Get Fulfillment Order List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListAllFulfillmentOrders_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListAllFulfillmentOrdersRequest request = new ListAllFulfillmentOrdersRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;

            ListAllFulfillmentOrdersResponse response = client.ListAllFulfillmentOrders(request);
            if (response.IsSetListAllFulfillmentOrdersResult())
            {
                ListAllFulfillmentOrdersResult listAllFulfillmentOrdersResult = response.ListAllFulfillmentOrdersResult;
                if (listAllFulfillmentOrdersResult.IsSetFulfillmentOrders())
                {
                    FulfillmentOrderList fulfillmentOrders = listAllFulfillmentOrdersResult.FulfillmentOrders;
                    List<FulfillmentOrder> memberList = fulfillmentOrders.member;
                    foreach (FulfillmentOrder member in memberList)
                    {
                        strbuff += "Order ID:" + member.SellerFulfillmentOrderId + System.Environment.NewLine;
                    }
                }
                txtListAllFulfillmentOrders.Text = strbuff;
            }

        }

        /// <summary>
        /// Get Next All Fulfillment Order 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListAllFulfillmentOrdersByNextToken_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            ListAllFulfillmentOrdersRequest request = new ListAllFulfillmentOrdersRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;

            ListAllFulfillmentOrdersResponse response = client.ListAllFulfillmentOrders(request);
            if (response.IsSetListAllFulfillmentOrdersResult())
            {
                if (response.ListAllFulfillmentOrdersResult.NextToken != null)
                {
                    ListAllFulfillmentOrdersByNextTokenRequest request1 = new ListAllFulfillmentOrdersByNextTokenRequest();
                    request1.SellerId = SellerId;
                    request1.Marketplace = MarketplaceId;
                    request1.MWSAuthToken = MWSAuthToken;
                    request1.NextToken = response.ListAllFulfillmentOrdersResult.NextToken;

                    ListAllFulfillmentOrdersByNextTokenResponse response1 = client.ListAllFulfillmentOrdersByNextToken(request1);
                    if (response1.IsSetListAllFulfillmentOrdersByNextTokenResult())
                    {
                        ListAllFulfillmentOrdersByNextTokenResult listAllFulfillmentOrdersByNextTokenResult = response1.ListAllFulfillmentOrdersByNextTokenResult;
                        if (listAllFulfillmentOrdersByNextTokenResult.IsSetFulfillmentOrders())
                        {
                            FulfillmentOrderList fulfillmentOrders = listAllFulfillmentOrdersByNextTokenResult.FulfillmentOrders;
                            List<FulfillmentOrder> memberList = fulfillmentOrders.member;
                            foreach (FulfillmentOrder member in memberList)
                            {
                                strbuff += "Order ID:" + member.SellerFulfillmentOrderId;
                            }
                        }
                    }
                    txtListAllFulfillmentOrdersByNextToken.Text = strbuff;
                }
            }
        }

        /// <summary>
        /// GetPackageTracking Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetPackageTrackingDetails_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetPackageTrackingDetailsRequest request = new GetPackageTrackingDetailsRequest();
            request.PackageNumber = 123;
            request.MWSAuthToken = MWSAuthToken;

            GetPackageTrackingDetailsResponse response = client.GetPackageTrackingDetails(request);
            if (response.IsSetGetPackageTrackingDetailsResult())
            {
                GetPackageTrackingDetailsResult getPackageTrackingDetailsResult = response.GetPackageTrackingDetailsResult;
                strbuff = "Delivery Company Code:" + getPackageTrackingDetailsResult.CarrierCode;
            }
            txtGetPackageTrackingDetails.Text = strbuff;
        }

        /// <summary>
        /// Cancel Fulfillment Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelFulfillmentOrder_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            CancelFulfillmentOrderRequest request = new CancelFulfillmentOrderRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;
            request.SellerFulfillmentOrderId = "Set Order ID";

            CancelFulfillmentOrderResponse response = client.CancelFulfillmentOrder(request);
        }

        /// <summary>
        /// Get Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetServiceStatus_Click(object sender, RoutedEventArgs e)
        {
            string SellerId = CommonValue.strMerchantId;
            string MarketplaceId = CommonValue.strMarketplaceId;
            string AccessKeyId = CommonValue.strAccessKeyId;
            string SecretKeyId = CommonValue.strSecretKeyId;
            string ApplicationVersion = CommonValue.strApplicationVersion;
            string ApplicationName = CommonValue.strApplicationName;
            string MWSAuthToken = CommonValue.strMWSAuthToken;
            string strbuff = string.Empty;

            FBAOutboundServiceMWSConfig config = new FBAOutboundServiceMWSConfig();
            config.ServiceURL = CommonValue.strServiceURL;

            FBAOutboundServiceMWSClient client = new FBAOutboundServiceMWSClient(
                                                            AccessKeyId,
                                                            SecretKeyId,
                                                            ApplicationName,
                                                            ApplicationVersion,
                                                            config);
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            request.SellerId = SellerId;
            request.Marketplace = MarketplaceId;
            request.MWSAuthToken = MWSAuthToken;

            // 処理実行
            GetServiceStatusResponse response = client.GetServiceStatus(request);
            if (response.IsSetGetServiceStatusResult())
            {
                GetServiceStatusResult getServiceStatusResult = response.GetServiceStatusResult;
                if (getServiceStatusResult.IsSetStatus())
                {
                    strbuff = "Status：" + getServiceStatusResult.Status;
                }
            }
            txtGetServiceStatus.Text = strbuff;
        }
    }
}
