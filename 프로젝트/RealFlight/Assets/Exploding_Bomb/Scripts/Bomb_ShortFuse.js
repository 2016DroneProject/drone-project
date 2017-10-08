
var FuseCentre : GameObject;
var FuseLight: Light;
var ExplodeVideoParticles : ParticleSystem;
var SparkTrailsParticles : ParticleSystem;
var SparkParticles : ParticleSystem;
var ExplodeAudio : AudioSource;
var Bomb : GameObject;
var FuseObject : GameObject;
var BombExplode : GameObject;
var BombExplodeAnim : AnimationClip;
var BurningFuseAudio : AudioSource;
var ExplodeLight : Light;

private var offset : float = 0;
private var fuselightintensity = 0.4;	
private var explodeset = 0;
private var explodehalt = 0;
private var nobomb = 0;
private var fadeStart = 1.5;
private var fadeEnd = 0;
private var fadeTime = 1;
private var t = 0.0;
private var fuseLit = 0;
  
function Start() 
{
	ExplodeLight.intensity = 0;
}  
  
  
function Update ()
{
 
	if (Input.GetButtonDown("Fire1")) //check to see if the left mouse was pressed - lights fuse
    {
              
    	if (nobomb != 1)
    	{
    	
    		if (fuseLit != 1)
    		{  
    		offset = 0;   	
     		Fuse();
     		BurningFuseAudio.Play();
     		FuseCentre.SetActive(true);
    		explodehalt = 0;
			explodeset = 0;
			}
		
     	}
     	 
    }
     
    if (Input.GetButtonDown("Fire2")) //check to see if the right mouse was pushed - resets bomb
    {
    
    	explodehalt = 1;
     	explodeset = 0;
     	offset = 0.5;
     	Bomb.SetActive(true);
     	FuseObject.SetActive(true);
     	FuseCentre.SetActive(false);
     	BombExplode.SetActive(false);
     	fuselightintensity = 0;
     	FuseObject.GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", Vector2(0,0));
     	ExplodeVideoParticles.Clear();
     	SparkParticles.Clear();
     	SparkTrailsParticles.Clear();
     	BurningFuseAudio.Stop();
     	ExplodeLight.intensity = 0;
     	nobomb = 0; 
     	fuseLit = 0;
     	
	}
     

      
    fuselightintensity = (Random.Range(0.2,0.4));
    FuseLight.intensity = fuselightintensity;
     
     
    if (explodeset == 1)
    {
    	Explosion();
    }
           
 }
 
 
function Fuse()
{
        
	while (offset < 0.43)
    {  
    	offset += (Time.deltaTime * 0.44);
     	FuseObject.GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", Vector2(offset,0));
     	fuseLit = 1;
     	yield;
    }
 
    if (explodehalt != 1)
    {
    	explodeset = 1; 
    }
     
    offset = 0;


}


function Explosion()
{
    
    FuseCentre.SetActive(false);
    Bomb.SetActive(false);
    BombExplode.SetActive(true); 
    explodeset = 0;
	ExplodeVideoParticles.Play();
    SparkParticles.Play();
    SparkTrailsParticles.Play();
    ExplodeAudio.Play();
    FadeLight();

    // nobomb = 1; 
}


function FadeLight()
{
	while (t < fadeTime) 
	{
    	t += Time.deltaTime;
		ExplodeLight.intensity = Mathf.Lerp(fadeStart, fadeEnd, t / fadeTime);
        yield;  
    }              
            
	t = 0;  
}
 
 

 