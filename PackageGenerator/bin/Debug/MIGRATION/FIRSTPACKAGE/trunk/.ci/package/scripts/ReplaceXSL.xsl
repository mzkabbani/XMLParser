<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
 <xsl:output omit-xml-declaration="yes" indent="yes"/>
 <xsl:param name="targetPath"/>
 <xsl:strip-space elements="*"/>

 <xsl:template match="node()|@*" name="identity">
  <xsl:copy>
   <xsl:apply-templates select="node()|@*"/>
  </xsl:copy>
 </xsl:template>

 <xsl:template match="#TARGETPATH#" >
#REPLACEMENTXML#
 </xsl:template>
 
</xsl:stylesheet>
