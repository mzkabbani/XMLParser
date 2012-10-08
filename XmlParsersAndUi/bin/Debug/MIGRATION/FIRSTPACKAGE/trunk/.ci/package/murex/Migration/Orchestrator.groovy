package murex.MXpress;
import java.io.File;


public class Orchestrator {
	//Globals
	public def ApplicationDirectoryPath;
	public def BackupDirectoryPath;
	public def TrashDirectory ; 
	
	
	//taken from installer
	public def MXPRESS_INSTALLER_DBVENDOR;
	
	//public boolean EnableMXOps=true;
	//public boolean EnableServiceLaunch=true;
	//public boolean EnableDMMImport=false;
	//public boolean EnableRTBS=true;
	//public boolean EnableERM=false;
	//public boolean EnableCleanup=true;
	
	public OrchestrateInstaler(def ApplicationDirectoryPath ,def MXPRESS_INSTALLER_DBVENDOR ,boolean EnableMXOps,boolean EnableServiceLaunch,boolean EnableDMMImport,boolean EnableRTBS,boolean EnableERM,boolean EnableCleanup){
		TrashDirectory =ApplicationDirectoryPath +"/logs/MXpress-Installer/output/trash";
		//setProperty (,)
		BackupDirectoryPath = ApplicationDirectoryPath+"/Backup";
		File logFile = new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log");
		if(logFile.exists()){
			logFile.delete();			
		}
		
		if(EnableMXOps){
			MxOperations mxO = new MxOperations();
			mxO.RunOperations(ApplicationDirectoryPath,BackupDirectoryPath);			
		}
		
		if(EnableServiceLaunch){
			LaunchServices launchServices = new LaunchServices();
			launchServices.LaunchMXpressServices(ApplicationDirectoryPath);			
		}	
		
		if(EnableDMMImport){
			DMMImport dmmImport = new DMMImport();
			dmmImport.RunDMMOperations( ApplicationDirectoryPath, MXPRESS_INSTALLER_DBVENDOR);
		}
		
		if(EnableRTBS){
			RTBSOperations rtbsOperations = new RTBSOperations();
			rtbsOperations.RunRTBSOperations(ApplicationDirectoryPath);
		}
		
		if(EnableERM){
			ERMOperations ermOperations = new ERMOperations();
			ermOperations.RunERMOperarions(ApplicationDirectoryPath,BackupDirectoryPath);
		}
		
		if(EnableCleanup){
			CleanupOperations cleanupOperations = new CleanupOperations();
			cleanupOperations.RunCleanupOperations(ApplicationDirectoryPath);
		}
		
	}
	
}
