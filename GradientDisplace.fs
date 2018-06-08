/*
{
  "CATEGORIES" : [
    "icalvin102"
  ],
  "DESCRIPTION" : "!!!work in progress!!! Creates a 2D-Gradientvector from a greyscale image and displaces the inputImage along this vector",
  "ISFVSN" : "2",
  "INPUTS" : [
    {
      "NAME" : "inputImage",
      "TYPE" : "image"
    },
    {
      "NAME" : "displace",
      "TYPE" : "image"
    },
    {
      "NAME" : "amount",
      "TYPE" : "float",
      "MAX" : 1,
      "DEFAULT" : 0.01,
      "MIN" : 0
    }
  ],
  "PASSES" : [
    {
      "DESCRIPTION" : "Main"
    }
  ],
  "CREDIT" : "icalvin102 (calvin@icalvin.de)"
}
*/

void main()	{
	vec2 uv = isf_FragNormCoord.xy;
	vec2 e = vec2(.0001, 0.0);
	vec2 g = vec2(IMG_NORM_PIXEL(displace, uv + e.xy).r -
				  			IMG_NORM_PIXEL(displace, uv - e.xy).r,
				  			IMG_NORM_PIXEL(displace, uv + e.yx).r -
				  			IMG_NORM_PIXEL(displace, uv - e.yx).r
	);
	g /= e.x;

	g *= IMG_NORM_PIXEL(displace, uv).r;

	gl_FragColor = IMG_NORM_PIXEL(inputImage, uv + g);

}
