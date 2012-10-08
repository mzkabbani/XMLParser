package murex.MXpress;


import java.io.File;


public class CleanupOperations extends Orchestrator{
	
	public RunCleanupOperations(def ApplicationDirectoryPath){
		FrontendUtilities utils = new FrontendUtilities();
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath);
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 6 - MXpress-Installer clean-up starts =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		def files  = []
        new File(ApplicationDirectoryPath).eachFileMatch (~/^.*\.sh$/){ files << it.path }
		 		
		
			for (int i = 0; i < files.size(); i++) {
				utils.ChmodFile(new File(files[i]), 777)
			}
			//MXpress-Installer temp files cleaning
		
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====Start: Deletion of "+ApplicationDirectoryPath+"/CleanDeploy =====")
			utils.DeleteDirectory(ApplicationDirectoryPath+"/CleanDeploy")
			//new File(ApplicationDirectoryPath+"/CleanDeploy").delete()
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====End: Deletion of "+ApplicationDirectoryPath+"/CleanDeploy =====")

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====Start: Deletion of "+ApplicationDirectoryPath+"/get_free_port.sh =====")
			new File(ApplicationDirectoryPath+"/get_free_port.sh").delete()
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====End: Deletion of "+ApplicationDirectoryPath+"/get_free_port.sh =====")

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====Start: Deletion of "+ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh =====")			
			new File(ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh").delete();
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=====End: Deletion of "+ApplicationDirectoryPath+"/MXpress-Installer-launchall.sh =====")

			//Consitency: locate all log files under the same directory
			utils.CopyFile(ApplicationDirectoryPath+"/freeport_res.log", ApplicationDirectoryPath+"/logs/MXpress-Installer/freeport_res.log")
			
			//rdm builder legacy
			new File(ApplicationDirectoryPath+"/aliasSequencing.txt").delete()
			
			//rdm builder legacy
			def rdmfiles  = []
            new File(ApplicationDirectoryPath).eachFileMatch (~/^rdm_.*\..*$/){ rdmfiles << it.path }
			for (int i = 0; i < rdmfiles.size(); i++) {f
				new File(rdmfiles).delete()
			}
			


					
			
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 6 - MXpress-Installer clean-up completed =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")

		//copy log file to logs dir
		File mxpressLogFile = new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log");
		utils.CopyFile(ApplicationDirectoryPath+"/MXpressInstallerLogs.log", ApplicationDirectoryPath+"/logs/MXpress-Installer/MXpressInstallerLogs.log")
		mxpressLogFile.delete();
		
	}
	
}
