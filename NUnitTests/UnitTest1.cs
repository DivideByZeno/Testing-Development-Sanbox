namespace NUnitTests;
using TestDrivenDevPractice;

[TestFixture]
public class StringExtensionsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WordCount()
    {
        Assert.That("one two three four".WordCount().Equals(4));
        Assert.That("These are two typical sentences. They contain nine words.".WordCount().Equals(9));
        Assert.False("Something".WordCount().Equals(0));
        Assert.False("".WordCount().Equals(1));
    }
}

[TestFixture]
public class IntExtensionsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ToCardinalResultNotEmpty([Random(-999, 999, 20)] int x)
    {
        Assert.IsNotEmpty(x.ToCardinal());
    }

    [Test]
    public void ToCardinalDigits()
    {
        Assert.True(0.ToCardinal().Equals("Zero"));
        Assert.True(4.ToCardinal().Equals("Four"));
        Assert.True(9.ToCardinal().Equals("Nine"));

        Assert.False(8.ToCardinal().Equals("Seven"));
        Assert.False(1.ToCardinal().Equals("Bananas"));
    }

    [Test]
    public void ToCardinalTens()
    {
        var thing = (10.ToCardinal());
        Assert.True(10.ToCardinal().Equals("Ten"));
        Assert.True(17.ToCardinal().Equals("Seventeen"));
        Assert.True(56.ToCardinal().Equals("Fifty Six"));
        Assert.True(70.ToCardinal().Equals("Seventy"));
        Assert.True(99.ToCardinal().Equals("Ninety Nine"));

        Assert.False(80.ToCardinal().Equals("Sixty"));
        Assert.False(11.ToCardinal().Equals("Ten"));
    }

    [Test]
    public void ToCardinalHundreds()
    {
        Assert.True(300.ToCardinal().Equals("Three Hundred"));
        Assert.True(176.ToCardinal().Equals("One Hundred Seventy Six"));
        Assert.True(110.ToCardinal().Equals("One Hundred Ten"));
        Assert.True(010.ToCardinal().Equals("Ten"));
        Assert.True(999.ToCardinal().Equals("Nine Hundred Ninety Nine"));

        Assert.False(800.ToCardinal().Equals("Eighty"));
        Assert.False(111.ToCardinal().Equals("Eleven"));
    }

    [Test]
    public void ToCardinalNegative()
    {
        Assert.True((-4).ToCardinal().Equals("Negative Four"));
        Assert.True((-13).ToCardinal().Equals("Negative Thirteen"));
        Assert.True((-456).ToCardinal().Equals("Negative Four Hundred Fifty Six"));

        Assert.False((-1).ToCardinal().Equals("One"));
        Assert.False((-0).ToCardinal().Equals("Negative Zero"));
    }

    [Test]
    public void ToCardinalRange()
    {
        Assert.True(1234.ToCardinal().Equals("Too big!"));
        Assert.False((-123).ToCardinal().Equals("Too big!"));
    }
}