void ProcessWorld()
{
    for (int x = 0; x < worldWidth; x++)
    {
        for (int y = 0; y < worldHeight; y++)
        {
            ProcessBlock(x, y);
        }
    }
}

void ProcessBlock(int x, int y)
{
    for (int i = 0; i < worldWidth * worldHeight; i++)
{
    int x = i % worldWidth;
    int y = i / worldWidth;
    ProcessBlock(x, y);
}

}
