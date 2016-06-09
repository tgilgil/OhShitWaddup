namespace Listener
{
    //todo 
    class OhShitWaddupDetector
    {
        private const string OhShitWaddup = "DAT BOI";

        public bool IsWorthyOhShitWaddup(string stringToCheck)
        {
            return stringToCheck.ToUpper().Contains(OhShitWaddup);
        }
    }
}
