public static class FormatHelper
{
    // Chuyển số tiền 25000 thành "25,000 VNĐ"
    public static string FormatMoney(decimal amount)
    {
        return amount.ToString("#,##0") + " VNĐ";
    }

    // Chuyển đổi Timestamp (VD: 1711900000000) thành DateTime
    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
}