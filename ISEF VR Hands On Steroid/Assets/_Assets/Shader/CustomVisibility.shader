Shader"Custom/SplitVisibilityShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _PlanePosition ("Plane Position", Vector) = (0, 1, 0, 0)
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }
LOD100

        CGPROGRAM
        #pragma surface surf Lambert

struct Input
{
    float3 worldPos;
};

sampler2D _MainTex;
float4 _PlanePosition;

void surf(Input IN, inout SurfaceOutput o)
{
            // Calculate visibility based on dot product with the plane normal
    fixed visibility = dot(IN.worldPos, _PlanePosition.xyz) - _PlanePosition.w > 0 ? 1 : 0;

            // Set the surface color (you can customize this part)
    o.Albedo = visibility * tex2D(_MainTex, IN.worldPos.xz).rgb;

            // You can add more surface properties as needed
    o.Alpha = 1;
}
        ENDCG
    }
FallBack"Diffuse"
}
