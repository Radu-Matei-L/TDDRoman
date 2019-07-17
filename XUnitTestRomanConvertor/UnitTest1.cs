using System;
using Shouldly;
using Xunit;
using TDDRoman;

namespace XUnitTestRomanConvertor
{
    public class RomanConvertorShould
    {
        private RomanConvertor convertor = new RomanConvertor();
        [Fact]
        public void ReturnTheCorrectArabicValueForTheRespectiveRomanLetter()
        {
            convertor.Convert("I").ShouldBe(1);
            convertor.Convert("V").ShouldBe(5);
            convertor.Convert("X").ShouldBe(10);
            convertor.Convert("L").ShouldBe(50);
            convertor.Convert("C").ShouldBe(100);
            convertor.Convert("D").ShouldBe(500);
            convertor.Convert("M").ShouldBe(1000);
        }

        [Fact]
        public void ReturnTheCorrectArabicValueForMultipleIdenticalRomanLetters()
        {
            convertor.Convert("II").ShouldBe(2);
            convertor.Convert("III").ShouldBe(3);
            convertor.Convert("XX").ShouldBe(20);
            convertor.Convert("XXX").ShouldBe(30);
            convertor.Convert("CC").ShouldBe(200);
            convertor.Convert("CCC").ShouldBe(300);
            convertor.Convert("MM").ShouldBe(2000);
            convertor.Convert("MMM").ShouldBe(3000);
        }

        [Fact]
        public void ReturnExceptionWhenRepeatingTheWrongRomanLetters()
        {
            Should.Throw<Exception>(() => { convertor.Convert("VV"); });
            Should.Throw<Exception>(() => { convertor.Convert("VVV"); });
            Should.Throw<Exception>(() => { convertor.Convert("LL"); });
            Should.Throw<Exception>(() => { convertor.Convert("LLL"); });
            Should.Throw<Exception>(() => { convertor.Convert("DD"); });
            Should.Throw<Exception>(() => { convertor.Convert("DDD"); });
        }

        [Fact]
        public void ReturnExceptionWhenTheStringIsNotARomanNumber()
        {
            Should.Throw<Exception>(() => { convertor.Convert("FJKSHASKJH"); });
        }

        [Fact]
        public void ReturnTheCorrectArabicValueForComposedNumbers()
        {
            convertor.Convert("VII").ShouldBe(7);
            convertor.Convert("VIII").ShouldBe(8);
            convertor.Convert("MIII").ShouldBe(1003);
            convertor.Convert("MMDCCXXVIII").ShouldBe(2728);
        }

        [Fact]
        public void ReturnTheCorrectArabicValueForNumbersObtainUsingDifferences()
        {
            convertor.Convert("IV").ShouldBe(4);
            convertor.Convert("IX").ShouldBe(9);
            convertor.Convert("CMXCIX").ShouldBe(999);
            convertor.Convert("XL").ShouldBe(40);
            convertor.Convert("DC").ShouldBe(400);
        }
    }
}
