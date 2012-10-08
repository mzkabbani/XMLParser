package murex.MXpress;



public class ERMOperations extends Orchestrator{

	public RunERMOperarions(def ApplicationDirectoryPath, def BackupDirectoryPath){
		FrontendUtilities utils = new FrontendUtilities();
		utils.SetUtilsAppdirPath(ApplicationDirectoryPath)
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 5 - ERM setup starts =======================================")
		utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		try{
			//Update fs/public/mxres/mxmlc/migration/migration.props
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath +"/fs/public/mxres/mxmlc/migration/migration.props"), "deactivate.mlc=yes", "deactivate.mlc=no")
			//Update fs/public/mxres/mxmlc/migration/migration.props to change source.mlcversion
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/migration/migration.props"), "source.mlcversion=(.*)", "source.mlcversion=mlc.1.6.build.1")

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxmlc/dbconfig/dbsourcemapping.mxres for MXDBSOURCE.MLC* =====")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/dbsourcemapping.mxres"), "(<DbLogicalSource>MXDBSOURCE.MLC.HISTORIZATION</DbLogicalSource>.*?<DbPhysicalSource>)public.mxres.common.dbconfig.dbsource.mxres(</DbPhysicalSource>)", "\$1public.mxres.mxmlc.dbconfig.dbsource_mlc.mxres\$2")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig/dbsourcemapping.mxres"), "(<DbLogicalSource>MXDBSOURCE.MLC.UPLOAD</DbLogicalSource>.*?<DbPhysicalSource>)public.mxres.mxmlc.dbconfig.dbsource_mlc.mxres(</DbPhysicalSource>)", "\$1public.mxres.common.dbconfig.dbsourcerep.mxres\$2")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxmlc/dbconfig/dbsourcemapping.mxres for MXDBSOURCE.MLC* =====")

			def dbSourcePath= ApplicationDirectoryPath+"/fs/public/mxres/common/dbconfig";
			def currentFsHostName = utils.FileTextMatched(new File(ApplicationDirectoryPath+"/mxg2000_settings.sh"), /MXJ_FILESERVER_HOST=(.*)/)[0][1].toString()
			def currentFsHostPort = utils.FileTextMatched(new File(ApplicationDirectoryPath+"/mxg2000_settings.sh"), /MXJ_FILESERVER_PORT=(.*)/)[0][1].toString()

			//def dbSourceMLC = utils.ReadFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"))

			def dbMlcName = utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbDatabaseOrSchemaName>)(.*)(<\/DbDatabaseOrSchemaName)/)[0][2]
			def dbMlcHost =utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbHostName>)(.*)(<\/DbHostName)/)[0][2]
			def dbMlcPort=  utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbServerPortNumber>)(.*)(<\/DbServerPortNumber)/)[0][2]
			def dbMlcServer=  utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbServerOrServiceName>)(.*)(<\/DbServerOrServiceName)/)[0][2]
			def dbMlcUser=  utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbUser>)(.*)(<\/DbUser)/)[0][2]
			def dbMlcPassword= utils.FileTextMatched(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/dbconfig/dbsource_mlc.mxres"), /(DbPassword>)(.*)(<\/DbPassword)/)[0][2]

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Updating fs/public/mxres/mxmlc/mlc_properties.mxres =====")
			//utils.BackupFile(ApplicationDirectoryPath +"/fs/public/mxres/common/launcherall.mxres",ApplicationDirectoryPath,BackupDirectoryPath)
			utils.BackupFile(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres",ApplicationDirectoryPath,BackupDirectoryPath)

			AntBuilder ant = new AntBuilder();

			ant.replace(file:ApplicationDirectoryPath + '/fs/public/mxres/mxmlc/mlc_properties.mxres') {
				replacefilter ( token : 'FSPORT' , value : currentFsHostPort )
				replacefilter ( token : 'FSHOST' , value : currentFsHostName )
			}

			utils.ChmodFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), 777)

			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.progs.lrb.PASSWORD</Code><Value>)(.*?)(</Value></Property>)", "murex.limits.progs.lrb.PASSWORD</Code><Value>0010002000410047001600b70067\$3")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.lrb.lts.PASSWORD</Code><Value>)(.*?)(</Value></Property>)", "murex.limits.lrb.lts.PASSWORD</Code><Value>0010002000410047001600b70067\$3")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.progs.lrb.USER</Code><Value>)(.*?)(</Value></Property>)", "\$1MUREXBO\$3")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.lrb.lts.USER</Code><Value>)(.*?)(</Value></Property>)", "\$1MUREXBO\$3")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.progs.lrb.GROUP</Code><Value>)(.*?)(</Value></Property>)", "\$1MLC_OPS\$3")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/mxmlc/mlc_properties.mxres"), "(murex.limits.lrb.lts.GROUP</Code><Value>)(.*?)(</Value></Property>)", "\$1MO\$3")

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Updating fs/public/mxres/mxmlc/mlc_properties.mxres =====")

			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Update fs/public/mxres/fs/fileserver.mxres to reference CollateralMarginCallLogo.jar =====")
			utils.RegexReplaceInFile(new File(ApplicationDirectoryPath+"/fs/public/mxres/fs/fileserver.mxres"), "(<MxAnchor Code=\"NONALONE\">)", "\$1<Path>public/code/mlc/CollateralMarginCallLogo.jar</Path>")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Update fs/public/mxres/fs/fileserver.mxres to reference CollateralMarginCallLogo.jar =====")


			//launch mlc_setup since no mlc setup

			/*			if(MXPRESS_INSTALLER_DBVENDOR.equals("SYB")){
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Execute /sqlscript/mlc/bin/mlc_setup =====")
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== mlc_setup -SERVER:$dbMlcServer -DATABASE:$dbMlcName -SANAME:sa -SAPASS: -MLCNAME:$dbMlcUser -MLCPASS:$dbMlcUser =====")
			 utils.ChmodFile(new File(ApplicationDirectoryPath+"/sqlscript/mlc/bin/mlc_setup"), 777)
			 utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/sqlscript/mlc/bin/mlc_setup -SERVER:$dbMlcServer -DATABASE:$dbMlcName -SANAME:sa -SAPASS: -MLCNAME:$dbMlcUser -MLCPASS:$dbMlcUser", new File(ApplicationDirectoryPath+"/sqlscript/mlc/bin"))
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Execute /sqlscript/mlc/bin/mlc_setup =====")				
			 }else{
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== Start: Execute /sqlscript/mlc/bin/mlc_setup_ora =====")
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== mlc_setup_ora $dbMlcServer $dbMlcName $dbMlcUser MUX92 =====")
			 utils.ChmodFile(new File(ApplicationDirectoryPath+"/sqlscript/mlc/bin/mlc_setup"), 777)
			 utils.ExecuteCommandInShell(ApplicationDirectoryPath+"/sqlscript/mlc/bin/mlc_setup_ora $dbMlcServer dbMlcName $dbMlcUser MUX92", new File(ApplicationDirectoryPath+"/sqlscript/mlc/bin"))
			 utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "===== End: Execute /sqlscript/mlc/bin/mlc_setup =====")
			 }
			 */
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "========================== MXpress-Installer - Stage 5 - ERM setup completed =======================================")
			utils.LogInfo(new File(ApplicationDirectoryPath+"/MXpressInstallerLogs.log"), "=================================================================================================================")
		}catch (Exception ex){
			println ex.message

		}



	}


}
