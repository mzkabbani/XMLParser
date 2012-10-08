package murex.Migration;

public class Packager {
	
	def pack(context) {	
		
		def ant = new AntBuilder()
		   
    	ant.copy(toDir:context.target,overwrite:true) {
		fileset(dir:context.source){			
			}
		}	
	}
}
