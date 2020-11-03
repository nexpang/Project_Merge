#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("GZqUm6sZmpGZGZqamx3IzK+9giN8tSPk4UGHm527Wo/41Aj18h7DRMzSeuYgvZmRAl9B6qafT6yiJB7LLuP2xmtki/bCkXd4Ly2Ir4K2uJjKF3mykp5SZegvmdUOxUoAi3wixTPifxG2hsQmF9566OijBrqp4wDZZCMwB3JPU/7HpmhUFQIfWGwlqGD+Pqf6BlC14H2XSAIMiwWI40QDtmEBvbpVT4TsKcZywjUblwwtbu8IY1ZB3Xb+ITHzqKfaKynOJs5EcuAPHXdVRSrCn4jGxn/k8ic5QxQYikF6Bq70bYeBDP//YM1z2VmyrNAlqxmauauWnZKxHdMdbJaampqem5hRmvhlzOa1vbCdeeCSvpbcmBC2NIZEAu97SpcU+pmYmpua");
        private static int[] order = new int[] { 1,11,4,7,4,9,13,7,9,9,10,12,12,13,14 };
        private static int key = 155;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
