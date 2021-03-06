package at.dotpoint.math.lazy;

import at.dotpoint.core.evaluate.EvaluateObject;
import at.dotpoint.core.evaluate.event.EvaluateEvent;
import at.dotpoint.core.dispatcher.event.Event;
import at.dotpoint.core.dispatcher.EventDispatcher;
import at.dotpoint.core.dispatcher.IEventDispatcher;
import at.dotpoint.core.evaluate.IEvaluateObject;
import at.dotpoint.math.MathUtil;
import at.dotpoint.math.vector.Vector3;

/**
 * Manages a Vector and notifies any listener about changes
 * @author Gerald Hattensauer
 */
class LazyVector3 extends Vector3 implements IEvaluateObject
{

	/**
	 * whether or not the object needs to be validated
	 * true - validate() required; false - invalidate() possible
	 */
	public var isInvalidated(get, null):Bool;
	
	/**
	 * true - executeValidation is currently running, useful to ignore followup invalidations
	 */
	public var isCurrentlyValidating(get, null):Bool;
	
	/**
	 * 
	 */
	public var evaluate:IEvaluateObject;
	
	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	public function new( x:Float = 0, y:Float = 0, z:Float = 0, ?evaluate:IEvaluateObject ) 
	{
		this.evaluate = evaluate != null ? evaluate : new EvaluateObject( null );		
		super( x, y, z );		
	}
	
	/**
	 * typical clone, but optional instance param which will be used
	 */
	override public function clone( ?output:Vector3 ):Vector3 
	{
		if( output != null && !Std.is( output, LazyVector3 ) )
			throw "must provide LazyVector3 instance for clone";
		
		return super.clone( output != null ? output : new LazyVector3() );
	}
	
	// ************************************************************************ //
	// Methodes
	// ************************************************************************ //	
	
	/**
	 * calls setComponents with the values of the given vector
	 */
	public function setVector( vector:Vector3 ):Void
	{
		this.setComponents( vector.x, vector.y, vector.z );
	}
	
	/**
	 * Sets the position to the given coordinates and notifies any listener about a change
	 * 
	 * use this methode when setting multiple values at once in order to avoid multiple event 
	 * broadcasts for the same batch of changes
	 */
	public function setComponents( x:Float, y:Float, z:Float ):Void
	{
		if ( MathUtil.isEqual( this.x, x ) 
		&& 	 MathUtil.isEqual( this.y, y ) 
		&& 	 MathUtil.isEqual( this.z, z ) ) return;
		
		this.x = x;
		this.y = y;
		this.z = z;
		
		this.invalidate();
	}	

	// ----------------------------------------------------------------------- //
	// ----------------------------------------------------------------------- //
	
	// x
	override private function set_x( x:Float ):Float
	{
		if ( !MathUtil.isEqual( super.x, x ) ) 
		{
			super.x = x;
			this.invalidate();
		}		
		
		return x;
	}
	
	// y
	override private function set_y( y:Float ):Float
	{
		if ( !MathUtil.isEqual( this.y, y ) ) 
		{
			super.y = y;
			this.invalidate();
		}
		
		return y;
	}
	
	// z
	override private function set_z( z:Float ):Float
	{
		if ( !MathUtil.isEqual( this.z, z ) ) 
		{
			super.z = z;
			this.invalidate();	
		}	
		
		return z;
	}
	
	// w
	override private function set_w( w:Float ):Float
	{
		if ( !MathUtil.isEqual( this.w, w ) ) 
		{
			super.w = w;
			this.invalidate();
		}	
		
		return w;
	}
	
	// ************************************************************************ //
	// IEvaluateObject
	// ************************************************************************ //	
	
	/**
	 * 
	 * @return
	 */
	private function get_isInvalidated():Bool
	{
		return this.evaluate.isInvalidated;
	}
	
	/**
	 * 
	 * @return
	 */
	private function get_isCurrentlyValidating():Bool
	{
		return this.evaluate.isCurrentlyValidating;
	}
	
	// ------------------------- //
	
	/**
	 * marks the object as invalid requiring a validate() call
	 * dispatches EvaluateEvent.INVALIDATED and EvaluateEvent.CHANGED
	 */
	public function invalidate():Void
	{
		this.evaluate.invalidate();
	}
	
	/**
	 * marks the object as valid again makes a vinalidate() call possible
	 * dispatches EvaluateEvent.VALIDATED
	 */
	public function validate():Void
	{
		this.evaluate.validate();
	}
	
	// ----------------------------------------------------------------------- //
	// ----------------------------------------------------------------------- //
	
	/**
	 * 
	 * @param	event
	 */
	public function dispatch( event:Event ):Bool
	{
		return this.evaluate.dispatch( event );
	}
	
	/**
	 * 
	 * @param	type
	 * @param	call
	 */
	public function addListener( type:String, call:Event->Void ):Void
	{
		this.evaluate.addListener( type, call );
	}
	
	/**
	 * 
	 * @param	type
	 * @param	call
	 */
	public function removeListener( type:String, call:Event->Void ):Void
	{
		this.evaluate.removeListener( type, call );
	}
	
	/**
	 * 
	 * @param	type
	 * @return
	 */
	public function hasListener( type:String ):Bool
	{
		return this.evaluate.hasListener( type );
	}
	
	/**
	 * 
	 * @param	type
	 * @return
	 */
	public function clearListeners():Void
	{
		return this.evaluate.clearListeners();
	}
	
}