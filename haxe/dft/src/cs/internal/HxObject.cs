using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public interface IHxObject {
		
		bool __hx_deleteField(string field, int hash);
		
		object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck);
		
		double __hx_lookupField_f(string field, int hash, bool throwErrors);
		
		object __hx_lookupSetField(string field, int hash, object @value);
		
		double __hx_lookupSetField_f(string field, int hash, double @value);
		
		double __hx_setField_f(string field, int hash, double @value, bool handleProperties);
		
		object __hx_setField(string field, int hash, object @value, bool handleProperties);
		
		object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties);
		
		double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties);
		
		object __hx_invokeField(string field, int hash, global::haxe.root.Array dynargs);
		
		void __hx_getFields(global::haxe.root.Array<object> baseArr);
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class HxObject : global::haxe.lang.IHxObject {
		
		public HxObject(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public HxObject() {
			global::haxe.lang.HxObject.__hx_ctor_haxe_lang_HxObject(this);
		}
		
		
		public static void __hx_ctor_haxe_lang_HxObject(global::haxe.lang.HxObject __temp_me24) {
		}
		
		
		public static object __hx_createEmpty() {
			return new global::haxe.lang.HxObject(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static object __hx_create(global::haxe.root.Array arr) {
			return new global::haxe.lang.HxObject();
		}
		
		
		public virtual bool __hx_deleteField(string field, int hash) {
			return false;
		}
		
		
		public virtual object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck) {
			if (isCheck) {
				return global::haxe.lang.Runtime.undefined;
			}
			else if (throwErrors) {
				throw global::haxe.lang.HaxeException.wrap("Field not found.");
			}
			else {
				return null;
			}
			
		}
		
		
		public virtual double __hx_lookupField_f(string field, int hash, bool throwErrors) {
			if (throwErrors) {
				throw global::haxe.lang.HaxeException.wrap("Field not found or incompatible field type.");
			}
			else {
				return default(double);
			}
			
		}
		
		
		public virtual object __hx_lookupSetField(string field, int hash, object @value) {
			throw global::haxe.lang.HaxeException.wrap("Cannot access field for writing.");
		}
		
		
		public virtual double __hx_lookupSetField_f(string field, int hash, double @value) {
			throw global::haxe.lang.HaxeException.wrap("Cannot access field for writing or incompatible type.");
		}
		
		
		public virtual double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			switch (hash) {
				default:
				{
					return this.__hx_lookupSetField_f(field, hash, @value);
				}
				
			}
			
		}
		
		
		public virtual object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			switch (hash) {
				default:
				{
					return this.__hx_lookupSetField(field, hash, @value);
				}
				
			}
			
		}
		
		
		public virtual object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			switch (hash) {
				default:
				{
					return this.__hx_lookupField(field, hash, throwErrors, isCheck);
				}
				
			}
			
		}
		
		
		public virtual double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			switch (hash) {
				default:
				{
					return this.__hx_lookupField_f(field, hash, throwErrors);
				}
				
			}
			
		}
		
		
		public virtual object __hx_invokeField(string field, int hash, global::haxe.root.Array dynargs) {
			switch (hash) {
				default:
				{
					return ((global::haxe.lang.Function) (this.__hx_getField(field, hash, true, false, false)) ).__hx_invokeDynamic(dynargs);
				}
				
			}
			
		}
		
		
		public virtual void __hx_getFields(global::haxe.root.Array<object> baseArr) {
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class DynamicObject : global::haxe.lang.HxObject {
		
		public DynamicObject(global::haxe.lang.EmptyObject empty) : base(global::haxe.lang.EmptyObject.EMPTY) {
		}
		
		
		public DynamicObject() {
			global::haxe.lang.DynamicObject.__hx_ctor_haxe_lang_DynamicObject(((global::haxe.lang.DynamicObject) (this) ));
		}
		
		
		public DynamicObject(global::haxe.root.Array<int> __hx_hashes, global::haxe.root.Array<object> __hx_dynamics, global::haxe.root.Array<int> __hx_hashes_f, global::haxe.root.Array<double> __hx_dynamics_f) {
			global::haxe.lang.DynamicObject.__hx_ctor_haxe_lang_DynamicObject(((global::haxe.lang.DynamicObject) (this) ), ((global::haxe.root.Array<int>) (__hx_hashes) ), ((global::haxe.root.Array<object>) (__hx_dynamics) ), ((global::haxe.root.Array<int>) (__hx_hashes_f) ), ((global::haxe.root.Array<double>) (__hx_dynamics_f) ));
		}
		
		
		public static void __hx_ctor_haxe_lang_DynamicObject(global::haxe.lang.DynamicObject __temp_me26) {
			__temp_me26.__hx_hashes = new global::haxe.root.Array<int>(new int[]{});
			__temp_me26.__hx_dynamics = new global::haxe.root.Array<object>(new object[]{});
			__temp_me26.__hx_hashes_f = new global::haxe.root.Array<int>(new int[]{});
			__temp_me26.__hx_dynamics_f = new global::haxe.root.Array<double>(new double[]{});
		}
		
		
		public static void __hx_ctor_haxe_lang_DynamicObject(global::haxe.lang.DynamicObject __temp_me25, global::haxe.root.Array<int> __hx_hashes, global::haxe.root.Array<object> __hx_dynamics, global::haxe.root.Array<int> __hx_hashes_f, global::haxe.root.Array<double> __hx_dynamics_f) {
			__temp_me25.__hx_hashes = __hx_hashes;
			__temp_me25.__hx_dynamics = __hx_dynamics;
			__temp_me25.__hx_hashes_f = __hx_hashes_f;
			__temp_me25.__hx_dynamics_f = __hx_dynamics_f;
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.lang.DynamicObject(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			unchecked {
				return new global::haxe.lang.DynamicObject(((global::haxe.root.Array<int>) (global::haxe.root.Array<object>.__hx_cast<int>(((global::haxe.root.Array) (arr[0]) ))) ), ((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (arr[1]) ))) ), ((global::haxe.root.Array<int>) (global::haxe.root.Array<object>.__hx_cast<int>(((global::haxe.root.Array) (arr[2]) ))) ), ((global::haxe.root.Array<double>) (global::haxe.root.Array<object>.__hx_cast<double>(((global::haxe.root.Array) (arr[3]) ))) ));
			}
		}
		
		
		public virtual string toString() {
			global::haxe.lang.Function ts = ((global::haxe.lang.Function) (global::haxe.lang.Runtime.getField(this, "toString", 946786476, false)) );
			if (( ts != null )) {
				return global::haxe.lang.Runtime.toString(ts.__hx_invoke0_o());
			}
			
			global::System.Text.StringBuilder ret_b = new global::System.Text.StringBuilder();
			ret_b.Append(((string) ("{") ));
			bool first = true;
			{
				int _g = 0;
				global::haxe.root.Array<object> _g1 = global::haxe.root.Reflect.fields(this);
				while (( _g < _g1.length )) {
					string f = global::haxe.lang.Runtime.toString(_g1[_g]);
					 ++ _g;
					if (first) {
						first = false;
					}
					else {
						ret_b.Append(((string) (",") ));
					}
					
					ret_b.Append(((string) (" ") ));
					ret_b.Append(((string) (global::haxe.root.Std.@string(f)) ));
					ret_b.Append(((string) (" : ") ));
					{
						object x = global::haxe.root.Reflect.field(this, f);
						ret_b.Append(((string) (global::haxe.root.Std.@string(x)) ));
					}
					
				}
				
			}
			
			if ( ! (first) ) {
				ret_b.Append(((string) (" ") ));
			}
			
			ret_b.Append(((string) ("}") ));
			return ret_b.ToString();
		}
		
		
		public override bool __hx_deleteField(string field, int hash) {
			unchecked {
				int res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes);
				if (( res >= 0 )) {
					this.__hx_hashes.splice(res, 1);
					this.__hx_dynamics.splice(res, 1);
					return true;
				}
				else {
					res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes_f);
					if (( res >= 0 )) {
						this.__hx_hashes_f.splice(res, 1);
						this.__hx_dynamics_f.splice(res, 1);
						return true;
					}
					
				}
				
				return false;
			}
		}
		
		
		public global::haxe.root.Array<int> __hx_hashes = new global::haxe.root.Array<int>(new int[]{});
		
		public global::haxe.root.Array<object> __hx_dynamics = new global::haxe.root.Array<object>(new object[]{});
		
		public global::haxe.root.Array<int> __hx_hashes_f = new global::haxe.root.Array<int>(new int[]{});
		
		public global::haxe.root.Array<double> __hx_dynamics_f = new global::haxe.root.Array<double>(new double[]{});
		
		public override object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck) {
			int res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes);
			if (( res >= 0 )) {
				return this.__hx_dynamics[res];
			}
			else {
				res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes_f);
				if (( res >= 0 )) {
					return this.__hx_dynamics_f[res];
				}
				
			}
			
			if (isCheck) {
				return global::haxe.lang.Runtime.undefined;
			}
			else {
				return null;
			}
			
		}
		
		
		public override double __hx_lookupField_f(string field, int hash, bool throwErrors) {
			int res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes_f);
			if (( res >= 0 )) {
				return this.__hx_dynamics_f[res];
			}
			else {
				res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes);
				if (( res >= 0 )) {
					return ((double) (global::haxe.lang.Runtime.toDouble(this.__hx_dynamics[res])) );
				}
				
			}
			
			return default(double);
		}
		
		
		public override object __hx_lookupSetField(string field, int hash, object @value) {
			unchecked {
				int res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes);
				if (( res >= 0 )) {
					return this.__hx_dynamics[res] = @value;
				}
				else {
					int res2 = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes_f);
					if (( res2 >= 0 )) {
						this.__hx_hashes_f.splice(res2, 1);
						this.__hx_dynamics_f.splice(res2, 1);
					}
					
				}
				
				this.__hx_hashes.insert( ~ (res) , hash);
				this.__hx_dynamics.insert( ~ (res) , @value);
				return @value;
			}
		}
		
		
		public override double __hx_lookupSetField_f(string field, int hash, double @value) {
			unchecked {
				int res = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes_f);
				if (( res >= 0 )) {
					return this.__hx_dynamics_f[res] = @value;
				}
				else {
					int res2 = global::haxe.lang.FieldLookup.findHash(hash, this.__hx_hashes);
					if (( res2 >= 0 )) {
						this.__hx_hashes.splice(res2, 1);
						this.__hx_dynamics.splice(res2, 1);
					}
					
				}
				
				this.__hx_hashes_f.insert( ~ (res) , hash);
				this.__hx_dynamics_f.insert( ~ (res) , @value);
				return @value;
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			{
				int __temp_i27 = default(int);
				int __temp_len28 = default(int);
				{
					__temp_i27 = 0;
					__temp_len28 = this.__hx_hashes.length;
					while (( __temp_i27 < __temp_len28 )) {
						baseArr.push(global::haxe.lang.FieldLookup.lookupHash(this.__hx_hashes[__temp_i27++]));
					}
					
				}
				
				{
					__temp_i27 = 0;
					__temp_len28 = this.__hx_hashes_f.length;
					while (( __temp_i27 < __temp_len28 )) {
						baseArr.push(global::haxe.lang.FieldLookup.lookupHash(this.__hx_hashes_f[__temp_i27++]));
					}
					
				}
				
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public interface IGenericObject : global::haxe.lang.IHxObject {
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class Enum : global::haxe.lang.HxObject {
		
		public Enum(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Enum(int index, global::haxe.root.Array<object> @params) {
			this.index = index;
			this.@params = @params;
		}
		
		
		public static new object __hx_createEmpty() {
			return new global::haxe.lang.Enum(global::haxe.lang.EmptyObject.EMPTY);
		}
		
		
		public static new object __hx_create(global::haxe.root.Array arr) {
			unchecked {
				return new global::haxe.lang.Enum(((int) (global::haxe.lang.Runtime.toInt(arr[0])) ), ((global::haxe.root.Array<object>) (global::haxe.root.Array<object>.__hx_cast<object>(((global::haxe.root.Array) (arr[1]) ))) ));
			}
		}
		
		
		public readonly int index;
		
		public readonly global::haxe.root.Array<object> @params;
		
		public string getTag() {
			object cl = global::haxe.root.Type.getClass<object>(this);
			return global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.callField(global::haxe.lang.Runtime.getField(cl, "constructs", 1744813180, true), "__get", 1915412854, new global::haxe.root.Array<object>(new object[]{this.index})));
		}
		
		
		public virtual string toString() {
			if (( ( this.@params == null ) || ( this.@params.length == 0 ) )) {
				return this.getTag();
			}
			
			global::System.Text.StringBuilder ret_b = new global::System.Text.StringBuilder();
			{
				string x = this.getTag();
				ret_b.Append(((string) (global::haxe.root.Std.@string(x)) ));
			}
			
			ret_b.Append(((string) ("(") ));
			bool first = true;
			{
				int _g = 0;
				global::haxe.root.Array<object> _g1 = this.@params;
				while (( _g < _g1.length )) {
					object p = _g1[_g];
					 ++ _g;
					if (first) {
						first = false;
					}
					else {
						ret_b.Append(((string) (",") ));
					}
					
					ret_b.Append(((string) (global::haxe.root.Std.@string(p)) ));
				}
				
			}
			
			ret_b.Append(((string) (")") ));
			return ret_b.ToString();
		}
		
		
		public override bool Equals(object obj) {
			if (global::haxe.lang.Runtime.eq(obj, this)) {
				return true;
			}
			
			global::haxe.lang.Enum obj1 = ((global::haxe.lang.Enum) (obj) );
			bool ret = ( ( ( obj1 != null ) && global::haxe.root.Std.@is(obj1, global::haxe.root.Type.getClass<object>(this)) ) && ( obj1.index == this.index ) );
			if ( ! (ret) ) {
				return false;
			}
			
			if (( obj1.@params == this.@params )) {
				return true;
			}
			
			int len = 0;
			if (( ( ( obj1.@params == null ) || ( this.@params == null ) ) || ( (len = this.@params.length) != obj1.@params.length ) )) {
				return false;
			}
			
			{
				int _g = 0;
				while (( _g < len )) {
					int i = _g++;
					if ( ! (global::haxe.root.Type.enumEq<object>(obj1.@params[i], this.@params[i])) ) {
						return false;
					}
					
				}
				
			}
			
			return true;
		}
		
		
		public override int GetHashCode() {
			unchecked {
				int h = 19;
				if (( this.@params != null )) {
					int _g = 0;
					global::haxe.root.Array<object> _g1 = this.@params;
					while (( _g < _g1.length )) {
						object p = _g1[_g];
						 ++ _g;
						h = ( h * 31 );
						if (( ! (global::haxe.lang.Runtime.refEq(p, null)) )) {
							h += p.GetHashCode();
						}
						
					}
					
				}
				
				h += this.index;
				return h;
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 295397041:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "GetHashCode", 295397041)) );
					}
					
					
					case 1955029599:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "Equals", 1955029599)) );
					}
					
					
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 589796196:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "getTag", 589796196)) );
					}
					
					
					case 1836776262:
					{
						return this.@params;
					}
					
					
					case 1041537810:
					{
						return this.index;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1041537810:
					{
						return ((double) (this.index) );
					}
					
					
					default:
					{
						return base.__hx_getField_f(field, hash, throwErrors, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, global::haxe.root.Array dynargs) {
			unchecked {
				switch (hash) {
					case 295397041:
					{
						return this.GetHashCode();
					}
					
					
					case 1955029599:
					{
						return this.Equals(dynargs[0]);
					}
					
					
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 589796196:
					{
						return this.getTag();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("params");
			baseArr.push("index");
			{
				base.__hx_getFields(baseArr);
			}
			
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}


