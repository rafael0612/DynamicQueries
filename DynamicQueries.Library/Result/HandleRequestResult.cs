namespace DynamicQueries.Library.Result;

public class HandleRequestResult<T>
{
    public bool Success { get; private set; }
    public T SucessValue { get; private set; }
    public string ErrorMessage { get; private set; }
    public HandleRequestResult(T Result)
    {
        Success = true;
        SucessValue = Result;
    }
    public HandleRequestResult(string ErrorMessage)
    {
        this.ErrorMessage = ErrorMessage;
        Success = false;
        
    }
}
