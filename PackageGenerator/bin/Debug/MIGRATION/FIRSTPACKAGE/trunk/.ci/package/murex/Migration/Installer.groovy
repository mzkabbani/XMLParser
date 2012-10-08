package murex.Migration;



public class Installer{
	AntBuilder ant 

	public Installer(){
		ant = new AntBuilder();
	}
	
	void buildWizard(def wizard, def machine) throws Exception {
		wizard {						
			welcomePage(message:'Welcome to the Package Installer',company:'MUREX',website:'www.murex.com',description:'Welcome Page')
			destinationPage(description:'Destination Page')
			licensePage(path:'./files/approval.txt',description:'License Page')
			//File dest = new File(wizard.getDestinationRoot())
			page(id:'settings.page',description:'Package Components Settings'){				
				
				Map<String, Object> props  = new HashMap<String, Object>();	
				
				property(name:'Customizations_Logs_Dir'){
					description = 'Logs directory'
					defaultValue = '/Logs';
				}
				
				property(name:'dbType') {
					description = 'Database server type'					
					type = DbType
				}
				
				props.put("Customizations_Logs_Dir", Customizations_Logs_Dir)
			
				
				property(name:'Customizations_Backup_Dir'){
					description = 'Backup directory'
					defaultValue = '/Backup';
				}				
				props.put("Customizations_Backup_Dir", Customizations_Backup_Dir)
			
				//Start-Properties


property(name:'GenericProp'){
description = 'GenericProp descp'
type = boolean
defaultValue = true
}
props.put("GenericProp", GenericProp)


//End-Properties
				
				install(){ installCtx ->
					//copy files from installCtx.source to target
					File dest = new File(wizard.getDestinationRoot())		
					ant.copy(todir:dest.getCanonicalPath(),overwrite:true) {
						fileset(dir:installCtx.getDataLocation()) {				
							include(name:'**/*')
						}
					}
					def test = dest.getCanonicalPath();
					println"======dest:$dest=== dest.path:$test ===="
					Operations operations = new Operations();
					//public def StartMigration(def AppDir, def logDir, def backupDir){
					operations.StartMigration(dest.getCanonicalPath(),Customizations_Logs_Dir,Customizations_Backup_Dir, props);
				
				}
			}
		}
	}
}

