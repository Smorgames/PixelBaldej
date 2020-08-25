[System.Serializable]
public class ObjectData
{
    public int colorIndex;
    public int shapeIndex;
    public int numberIndex;

    public bool IsDataInformationSimilar(int indexForColor, int indexForShape, int indexForNumber)
    {
        if (colorIndex == indexForColor && shapeIndex == indexForShape && numberIndex == indexForNumber)
            return true;
        else
            return false;
    }
}