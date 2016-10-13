namespace AzureDataLake.ODataQuery
{
    public class ExprDateLiteral : Expr
    {
        public System.DateTime DateTime;

        public ExprDateLiteral(System.DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        public override void ToExprString(ExBuilder sb)
        {
            // due to issue: https://github.com/Azure/autorest/issues/975,
            // date time offsets must be explicitly escaped before being passed to the filter

            string datestring = this.DateTime.ToString("O");
            var escaped_datestring = System.Uri.EscapeDataString(datestring);
            sb.Append(string.Format("datetimeoffset'{0}'", escaped_datestring));
        }
    }
}