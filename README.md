# FixSpikeForPolygon

This project is demo that shows an idea to solve the spike effect for some polygon.

Some geo processing result for polygon might has this effect what I call it "spike".

![old](https://github.com/Howard-ThinkGeo/FixSpikeForPolygon/blob/master/images/1.png?raw=true)

Then call this method to make the polygon smooth. It comes with two tolerance options you can playaround.

```
SmoothenHelper.Smoothen(polygon);
```

The result is this.

![new](https://github.com/Howard-ThinkGeo/FixSpikeForPolygon/blob/master/images/2.png?raw=true)

This is not that perfect, but at least an idea to solve this issue.