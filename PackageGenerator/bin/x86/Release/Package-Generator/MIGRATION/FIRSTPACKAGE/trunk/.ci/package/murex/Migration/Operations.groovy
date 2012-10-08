package murex.Migration;

public class Operations {
	
	public def StartMigration(def AppDir, def logDir, def backupDir, Map<String, Object> properties){		
		println "Package Deployment Starting!"
		println "AppDir======>" + AppDir;
		println "logDir======>" + logDir;
		println "backupDir===>" + backupDir;		
		boolean logFileExists =  new File(AppDir+logDir+"/CustomizationsLog.log").exists();
		
		if	(logFileExists){		
		println "This Package has already been run before!";
		return;
		}
		
		FrontendUtilities frontEndUtilities = new FrontendUtilities();
		frontEndUtilities.SetUtilsAppdirPath(AppDir);
		frontEndUtilities.SetUtilsLogDir(logDir);
		frontEndUtilities.SetUtilsBackupDir(backupDir);
	
		
		
		
		
		
		
	def PROP_GenericProp = properties.get("GenericProp");


//Start-Operations
	
	/*Comment for AppendToNodeInFileUsingXpathAsChild*/
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( AppDir + "/fs/public/mxres/common/launchermxprocessingrof.mxres" ,"//MxAnchors/MxAnchor/AvailableService/Import/Customize/DefaultCommands" ,"<DefaultCommand>/ROF_INCLUDE_PURGED_DEALS</DefaultCommand>" ,"<DefaultCommands>" );
	
	/*Comment for ReplaceKeyValueInFileWithEquals*/
	frontEndUtilities.ReplaceKeyValueInFileWithEquals( AppDir + "/fs/public/mxres/mxmigration/migration.props" ,"source.mxversion" ,"2.10.92.trinkaus" ,true );
	
	/*Comment for AppendToNodeInFileUsingXpath*/
	frontEndUtilities.AppendToNodeInFileUsingXpath( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='EnableDefaultTypologiesCreation']" ,"<setting name = \"Back2BackPackages\"><packages><package><code>B2B</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2BE</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2BI</code><mainTradeIndex>0</mainTradeIndex></package><package><code>B2IE</code><mainTradeIndex>0</mainTradeIndex></package></packages></setting>" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='EnableDefaultTypologiesCreation']//text()" ,"99" );
	
	/*Comment for AppendToNodeInFileUsingXpathAsChild*/
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='tradeRepository']//setting[@name='LtiCode2FreePackage']/packages" ,"<package><code>SUM1</code></package>" ,"<packages>" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='generalRights']//setting[@name='DefaultMigrationRights']//text()" ,"0" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='RefreshOptimizationFields']//setting[@name='Scanner']//text()" ,"3" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//domains/domain[@name='RefreshOptimizationFields']//setting[@name='ROFIncludeTypologiesMigration']//text()" ,"true" );
	
	/*Comment for AppendToNodeInFileUsingXpathAsChild*/
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild(AppDir + "/fs/public/mxres/mxmigration/settings.mxres" ,"//MxAnchors/MxAnchor[@Code='Target']" ,"<TemplateName>PC_PROC_TPL</TemplateName>" ,"<MxAnchor Code=\"Target\">" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[1]/text()" ,"/USER:MUREXFO" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[2]/text()" ,"/PASSWORD:0010002000410047001600f70067" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[3]/text()" ,"/GROUP:TSS BO" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='CTLIBDefaultCredential']//DefaultCommand[4]/text()" ,"/DESK:BO" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[1]/text()" ,"/USER:MUREXFO" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[2]/text()" ,"/PASSWORD:0010002000410047001600f70067" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[3]/text()" ,"/GROUP:TSS BO" );
	
	/*Comment for SetNodeTextValueInFileUsingXpath*/
	frontEndUtilities.SetNodeTextValueInFileUsingXpath( AppDir + "/fs/public/mxres/common/dbconfig/mxservercredential.mxres" ,"//MxAnchors/MxAnchor[@Code='MXMLCredential']//DefaultCommand[4]/text()" ,"/DESK:BO" );
	
	/*Comment for AppendTextToFile*/
	frontEndUtilities.AppendTextToFile( AppDir + "/launchall.sh" ,"launchmxj.app -aagent" );
	
	/*Comment for AppendTextToFile*/
	frontEndUtilities.AppendTextToFile( AppDir + "/launchall.sh" ,"sleep 10" );
	
	/*Comment for AppendTextToFile*/
	frontEndUtilities.AppendTextToFile( AppDir + "/launchall.sh" ,"launchmxj.app -rtbs" );
	
	/*Comment for AppendTextToFile*/
	frontEndUtilities.AppendTextToFile( AppDir + "/launchall.sh" ,"sleep 10" );
	
	/*Comment for AppendToNodeInFileUsingXpathAsChild*/
	frontEndUtilities.AppendToNodeInFileUsingXpathAsChild( AppDir + "/fs/public/mxres/common/launcherall.mxres" ,"//AvailableService[Code/text()='MXDATAPUBLISHER']//DefaultCommands" ,"<MxInclude MxAnchor=\"public.mxres.common.defaultarguments.mxres#MXRESDefaultArguments\" MxAnchorType=\"Include\"/>" ,"<DefaultCommands>" );
	//End-Operations
		
}}





















