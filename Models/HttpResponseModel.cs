namespace api.Models
{
    public enum HttpResponseType
    {
        FAIL,
        OK
    }
    public class HttpResponseModel
    {
        // 1 : 成功 ( 其餘為錯誤訊息代碼, NotFound 為格式錯誤，前端一律顯示 XXX 失敗 )
        public HttpResponseType Code { get; set; }
        // 回應資訊
        public object Data { get; set; }
    }
}