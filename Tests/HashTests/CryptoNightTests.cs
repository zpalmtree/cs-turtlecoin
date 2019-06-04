using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Canti.Blockchain.Crypto;
using Canti.Blockchain.Crypto.CryptoNight;
using Canti.Data;

/* https://cryptonote.org/cns/cns008.txt */
namespace Tests
{
    [TestClass]
    public class CryptoNightTests
    {
        /* This is hex data in the C++ code, wheras our other inputs are ascii -
           So convert to ascii so the hash is as expected rather than being
           double hexified. */
        private static string INPUT_DATA = Encoding.HexStringToString("0100fb8e8ac805899323371bb790db19218afd8db8e3755d8b90f39b3d5506a9abce4fa912244500000000ee8146d49fa93ee724deb57d12cbc6c6f3b924d946127c7a97418f9348828f0f02");

        [TestMethod]
        public void TestCNV0()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "eb14e8a833fac6fe9a43b57b336789c46ffe93f2868452240720607b14387e11" },
                { "The quick brown fox jumps over the lazy dog", "3ebb7f9f7d273d7c318d869477550cc800cfb11b0cadb7ffbdf6f89f3a471c59" },
                { "The quick brown fox jumps over the lazy dog.", "e37cc1b6fabcd3652b6d2879ac806e39f591f9d1c20be0c6b99cf6bef31158a2" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "d986f765ad299c605eba4712ffe11918ed9f39c4358949fd11a2cfd3f04fab35" },
                { INPUT_DATA, "1b606a3f4a07d6489a1bcd07697bd16696b61c8ae982f61a90160f4e52828a7f" },
            };

            HashTests.Test(testVectors, new CNV0());
        }

        [TestMethod]
        public void TestCNV0PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "eb14e8a833fac6fe9a43b57b336789c46ffe93f2868452240720607b14387e11" },
                { "The quick brown fox jumps over the lazy dog", "3ebb7f9f7d273d7c318d869477550cc800cfb11b0cadb7ffbdf6f89f3a471c59" },
                { "The quick brown fox jumps over the lazy dog.", "e37cc1b6fabcd3652b6d2879ac806e39f591f9d1c20be0c6b99cf6bef31158a2" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "d986f765ad299c605eba4712ffe11918ed9f39c4358949fd11a2cfd3f04fab35" },
                { INPUT_DATA, "1b606a3f4a07d6489a1bcd07697bd16696b61c8ae982f61a90160f4e52828a7f" },
            };

            HashTests.Test(testVectors, new CNV0(false));
        }

        [TestMethod]
        public void TestCNV1()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "The quick brown fox jumps over the lazy dog", "94f5dec524fad6d32004c55c035e5ea223e7315be20e2dc5b8a0ac7464ffeb1f" },
                { "The quick brown fox jumps over the lazy dog.", "86d34efc73e709dcc0f862725be692d1f8c5b407b4d730cd309acf80cc8f7c73" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "246e1f4e7a61e0b29d4fefe33bb48b175468d28c0e44e84cb0cf244be8af9a12" },
                { INPUT_DATA, "c9fae8425d8688dc236bcdbc42fdb42d376c6ec190501aa84b04a4b4cf1ee122" },
            };

            HashTests.Test(testVectors, new CNV1());
        }

        [TestMethod]
        public void TestCNV1PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "The quick brown fox jumps over the lazy dog", "94f5dec524fad6d32004c55c035e5ea223e7315be20e2dc5b8a0ac7464ffeb1f" },
                { "The quick brown fox jumps over the lazy dog.", "86d34efc73e709dcc0f862725be692d1f8c5b407b4d730cd309acf80cc8f7c73" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "246e1f4e7a61e0b29d4fefe33bb48b175468d28c0e44e84cb0cf244be8af9a12" },
                { INPUT_DATA, "c9fae8425d8688dc236bcdbc42fdb42d376c6ec190501aa84b04a4b4cf1ee122" },
            };

            HashTests.Test(testVectors, new CNV1(false));
        }

        /* V1 requires input length of >= 43 bytes */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCNV1Throws()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "" }
            };
            HashTests.Test(testVectors, new CNV1());
        }

        [TestMethod]
        public void TestCNLiteV0()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "4cec4a947f670ffdd591f89cdb56ba066c31cd093d1d4d7ce15d33704c090611" },
                { "The quick brown fox jumps over the lazy dog", "fbbbc024c37acff2e7302275458447f888a8d6361ce407c391be72ed34c16fee" },
                { "The quick brown fox jumps over the lazy dog.", "6d0e743fca6358bd0e9b365a68887fa9abf9f2940fe50682be28759b776d0fb0" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "38c887c08c2c9398d411c4bbf9b3eb707087906a5326ebeb3b238e7867fb1a9b" },
                { INPUT_DATA, "28a22bad3f93d1408fca472eb5ad1cbe75f21d053c8ce5b3af105a57713e21dd" },
            };

            HashTests.Test(testVectors, new CNLiteV0());
        }

        [TestMethod]
        public void TestCNLiteV0PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "4cec4a947f670ffdd591f89cdb56ba066c31cd093d1d4d7ce15d33704c090611" },
                { "The quick brown fox jumps over the lazy dog", "fbbbc024c37acff2e7302275458447f888a8d6361ce407c391be72ed34c16fee" },
                { "The quick brown fox jumps over the lazy dog.", "6d0e743fca6358bd0e9b365a68887fa9abf9f2940fe50682be28759b776d0fb0" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "38c887c08c2c9398d411c4bbf9b3eb707087906a5326ebeb3b238e7867fb1a9b" },
                { INPUT_DATA, "28a22bad3f93d1408fca472eb5ad1cbe75f21d053c8ce5b3af105a57713e21dd" },
            };

            HashTests.Test(testVectors, new CNLiteV0(false));
        }

        [TestMethod]
        public void TestCNLiteV1()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "The quick brown fox jumps over the lazy dog", "973a324237703e0f2ebe678a0000a00afb14c2c394c1859c84bcaa7b90bc56db" },
                { "The quick brown fox jumps over the lazy dog.", "b860f59d6aef32c7cacac02c4ac794066402dbd30c64c7fb733600a91441326d" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "f7a5217873b802940a629573f6a100deb25764af254f8f4fef1a8b9d51ef3cc5" },
                { INPUT_DATA, "87c4e570653eb4c2b42b7a0d546559452dfab573b82ec52f152b7ff98e79446f" },
            };

            HashTests.Test(testVectors, new CNLiteV1());
        }

        [TestMethod]
        public void TestCNLiteV1PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "The quick brown fox jumps over the lazy dog", "973a324237703e0f2ebe678a0000a00afb14c2c394c1859c84bcaa7b90bc56db" },
                { "The quick brown fox jumps over the lazy dog.", "b860f59d6aef32c7cacac02c4ac794066402dbd30c64c7fb733600a91441326d" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "f7a5217873b802940a629573f6a100deb25764af254f8f4fef1a8b9d51ef3cc5" },
                { INPUT_DATA, "87c4e570653eb4c2b42b7a0d546559452dfab573b82ec52f152b7ff98e79446f" },
            };

            HashTests.Test(testVectors, new CNLiteV1(false));
        }

        /* V1 requires input length of >= 43 bytes */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCNLiteV1Throws()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "" }
            };
            HashTests.Test(testVectors, new CNLiteV1());
        }

        /*
        [TestMethod]
        public void TestCNV2()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "e34985722288be50a2068f973f02248d62e7bc6a0a0dfca2eb84909724857a72" },
                { "The quick brown fox jumps over the lazy dog", "89dc534dd473da35f6360dcdc5583aa54279d4370475a46d623463e5d2846c13" },
                { "The quick brown fox jumps over the lazy dog.", "6426bc9c004916344b27e66cbc64f7efc1f4f7c7fba00a37e6928915ae88a552" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "17ef5baf4fe920df66387a719e6df60f5441fc79f3c1684aa925e72358b2bdaf" },
                { INPUT_DATA, "871fcd6823f6a879bb3f33951c8e8e891d4043880b02dfa1bb3be498b50e7578" },
            };

            HashTests.Test(testVectors, new CNV2());
        }
        */

        [TestMethod]
        public void TestCNV2PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "e34985722288be50a2068f973f02248d62e7bc6a0a0dfca2eb84909724857a72" },
                { "The quick brown fox jumps over the lazy dog", "89dc534dd473da35f6360dcdc5583aa54279d4370475a46d623463e5d2846c13" },
                { "The quick brown fox jumps over the lazy dog.", "6426bc9c004916344b27e66cbc64f7efc1f4f7c7fba00a37e6928915ae88a552" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "17ef5baf4fe920df66387a719e6df60f5441fc79f3c1684aa925e72358b2bdaf" },
                { INPUT_DATA, "871fcd6823f6a879bb3f33951c8e8e891d4043880b02dfa1bb3be498b50e7578" },
            };

            HashTests.Test(testVectors, new CNV2(false));
        }

        /*
        [TestMethod]
        public void TestCNTurtleV2()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "16cba4f89786b8aa785a4085f529f757296402aca4edbaefc1470bc691071ed9" },
                { "The quick brown fox jumps over the lazy dog", "32406c24600411f331e8a1decf38b65442a2feb6a3b71384bb50473e3e0dc11b" },
                { "The quick brown fox jumps over the lazy dog.", "9684a0c6bc9d1256bb64ee9eaecf429e545073a3a06d88478cd4d2aa6f15263c" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "decefe366f49f7fc26c8b4f87caf7da47552162c236ebc1819c851bc37861ae0" },
                { INPUT_DATA, "b2172ec9466e1aee70ec8572a14c233ee354582bcb93f869d429744de5726a26" },
            };

            HashTests.Test(testVectors, new CNTurtleV2());
        }
        */

        [TestMethod]
        public void TestCNTurtleV2PlatformIndependent()
        {
            var testVectors = new Dictionary<string, string>
            {
                { "", "16cba4f89786b8aa785a4085f529f757296402aca4edbaefc1470bc691071ed9" },
                { "The quick brown fox jumps over the lazy dog", "32406c24600411f331e8a1decf38b65442a2feb6a3b71384bb50473e3e0dc11b" },
                { "The quick brown fox jumps over the lazy dog.", "9684a0c6bc9d1256bb64ee9eaecf429e545073a3a06d88478cd4d2aa6f15263c" },
                { "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself", "decefe366f49f7fc26c8b4f87caf7da47552162c236ebc1819c851bc37861ae0" },
                { INPUT_DATA, "b2172ec9466e1aee70ec8572a14c233ee354582bcb93f869d429744de5726a26" },
            };

            HashTests.Test(testVectors, new CNTurtleV2(false));
        }
    }
}
