﻿Shader "Custom/ocean" 
{
	Properties 
	{
		_N 			("N", 			Range(4.0, 	512.0) ) 	= 64
		_L 			("LN", 			Range(4.0, 	512.0) ) 	= 64
		_gravity 	("_gravity", 	Range(0.0, 	20.0 ) ) 	= 9.81
		_frequency 	("frequency", 	Range(1.0, 200.0) ) 	= 200.0
		_sharpness 	("sharpness", 	Range(0.0, 32.0) ) 		= 8.0
		_amplitude 	("amplitude", 	Range(0.0, 32.0) ) 		= 8.0
		_MainTex 	("wavemap", 2D ) = ""
	}
	
	SubShader 
	{
		Pass 
		{
			Tags { "LightMode" = "ForwardBase" }
			
			CGPROGRAM		
			#pragma vertex vert
			#pragma fragment frag

			// ************************************************************************ //
			// DFT Wave Shader
			// ************************************************************************ //

			float   	_N;
			float   	_L;
			float   	_gravity;
			float   	_frequency;
			float   	_amplitude;
			float   	_sharpness;
			sampler2D   _MainTex;    
			
			struct vInput
		    {
		         float4 pos     	:POSITION;
		         float2 uv     		:TEXCOORD0;
		    };

			struct vOutput
			{
				float4 pos     	:SV_POSITION;
				float3 norm		:NORMAL;
		    };
			
			// ************************************************************************ //
			// Vertex-Shader
			// ************************************************************************ //
			
			//
			// k based on n,m
			//
			float2 getK( int n, int m, float2 k )
			{
				k.x = 6.28318530718 * (n - _N * 0.5) / _L;
				k.y = 6.28318530718 * (m - _N * 0.5) / _L;

				return k;
			}
			
			//
			//
			//
			float dispertion( float2 k )
			{
				float w0 = 6.28318530718 / _frequency;
				float wk = sqrt( _gravity * sqrt( k.x * k.x + k.y * k.y ) );
				
				return trunc( wk / w0 ) * w0;
			}
			
			//
			// h~(x,t) = h0(k) * exp( i * w(k) * t ) + h0'(-k) * exp( -i * w(k) * t );
			//
			float2 ht( int n, int m, float2 k, float t, float2 c_ht, vInput v )
			{
				float4 map = tex2Dlod( _MainTex, float4(n/_N,m/_N,0,0) );
			
				float2 h01 = (map.rg - 0.5) / 1000;	// h0(k);
				float2 h02 = (map.ba - 0.5) / 1000;	// h0'(-k) ... conjungat of h0;
				
				float w = dispertion( k ) * t;	// w(k) * t;
				
				// ---------------- //
				
				float c_cos1 = cos(  w );
				float c_sin1 = sin(  w );
				
				float c_cos2 = cos( -w );
				float c_sin2 = sin( -w );
				
				c_ht.x = ( h01.x * c_cos1 - h01.y * c_sin1 ) + ( h02.x * c_cos2 - h02.y * c_sin2 ); 	// h0 * exp(i * w * t) + h0' * exp(-i * w * t)  ... -i!
				c_ht.y = ( h01.x * c_sin1 + h01.y * c_cos1 ) + ( h02.x * c_sin2 + h02.y * c_cos2 ); 	// complex( x1*x2 - y1*y2, x1*y2 + y1*x2 ); ... euler sin/cos
				
				// ---------------- //
				
				return c_ht;
			}

			//
			// h( x, t ) = sum(k,N,M){ h0(k) * exp( i * w(k) * t ) + h0*(-k) * exp( -i * w(k) * t ) };
			//
			vOutput vert( vInput v )
		    {   
		    	float2	x		= float2( v.pos.x, v.pos.y );
		    	
		    	float2	h 		= float2(0.0, 0.0);			// height		    	
		    	float2	d		= float2(0.0, 0.0);			// x,y sharpness
		    	float3	t		= float3(0.0, 0.0, 1.0);	// normal
		    	
		    	// ---------------- //
		    	
		    	float2	k 		= float2(0.0, 0.0);
		    	float2	c_ht	= float2(0.0, 0.0);
		    	
			    for( int n = 0; n < _N + 1; n++ )
			    {
			    	for( int m = 0; m < _N + 1; m++ )
			    	{
			    		k = getK( n, m, k );
			    		
			    		// -------- //			    		
			    		
			    		float 	dot_kx 	= k.x * x.x + k.y * x.y;			// dot( k, x );
			    		
			    		float	c_cos = cos( dot_kx );						// exp( i * dot(k,x) ); ... euler sin/cos
			    		float	c_sin = sin( dot_kx );
			    		
			    		c_ht = ht( n, m, k, _Time.y, c_ht, v );				// h0(k) * exp( i * w(k) * t ) + h0*(-k) * exp( -i * w(k) * t );
			    		
	    				float c_htx = c_ht.x * c_cos - c_ht.y * c_sin;		// h~(k,t) * exp( i * dot(k,x) )
	    				float c_hty = c_ht.x * c_sin + c_ht.y * c_cos; 		// complex( x1*x2 - y1*y2, x1*y2 + y1*x2 );
			    		
			    		// -------- //		    		
			    		
			    		h.x += c_htx;
						h.y += c_hty;
						
						float	k_leng  = sqrt( k.x * k.x + k.y * k.y ) + 0.0000001;
						
						d.x += (k.x / k_leng) * c_hty;
						d.y += (k.y / k_leng) * c_hty;
						
						t.x += -k.x * c_hty;
						t.y += -k.y * c_hty;						
			    	}
		        } 
		        
		        // ---------------- //

		        vOutput o; 
			     
		        o.pos = v.pos;
		        o.pos.x += d.x * -_sharpness;	
		        o.pos.y += d.y * -_sharpness;	
		        o.pos.z = h.x * _amplitude;	
		        
		        o.norm 	= normalize( float3(0.0, 0.0, 1.0 ) - t );           	 
		        o.pos 	= mul( UNITY_MATRIX_MVP, o.pos );

		        return o;
		    }
			
			// ************************************************************************ //
			// Fragment-Shader
			// ************************************************************************ //
			
			//
			// fragment shader
			//
			fixed4 frag( vOutput v ):COLOR 
		    {
		        float3  norm  = v.norm; //normalize( cross( ddx( v.opos ), ddy( v.opos ) ) );             
	            float   lpow  = dot( normalize( _WorldSpaceLightPos0.xyz ), norm );

	            return fixed4( 0.0, 0.0, 1.0, 1.0) * ( lpow * 0.4 + 0.6 );
		    }
			
			ENDCG
		}	
	} 
	FallBack "Diffuse"
}