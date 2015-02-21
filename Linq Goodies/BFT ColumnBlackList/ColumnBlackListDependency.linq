<Query Kind="Statements">
  <Connection>
    <ID>8dc5c7bc-252a-4df3-9e3f-8871195602a9</ID>
    <Persist>true</Persist>
    <Server>dmsql05</Server>
    <Database>MetricsMetadataDev</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var input = @"Experiments,IsBlacklistBot,IsModelBot,IsPerfPingBot,OnlineBotCategory,IsFormBlacklistBot,IsIPBlacklistBot,IsQueryBlacklistBot,IsUABlacklistBot,IsUAContainsBlacklistBot,IsSecurityVulnerabilityBot,IsStealthBot,PageViewWithAdsClick,PageViewWithAdsPresent,PageViewWithAlgoClick,PageViewWithAlgoPresent,PageViewwithAnswerClick,PageViewwithAnswerPresent,PageViewWithClick,IsBotHotfix,PVMatchFormBlacklist,PVMatchIPBlacklist,PVMatchQueryBlacklist,PVMatchUABlacklist,PVMatchUAContainsBlacklist,UniqueUserCount_ANID,UniqueUserCount_ClosureId,UniqueUserCount_FBID,UniqueSessionCount,UniqueUserCount,UniqueUserCount_ClientID,FlightLevel,FlightFactor,QueryClassification,CoreResultsRegionClickedUrl,AdPageClickRate,AdConditionalClickRate,AdCoverage,AdultAdPageClickRate,AdultAdConditionalClickRate,AdultAdCoverage,AnswerBarPageClickRate,AnswerBarConditionalClickRate,AnswerBarCoverage,AnswerPageClickRate,AnswerConditionalClickRate,AnswerCoverage,AutosuggestPageClickRate,AutosuggestConditionalClickRate,AutosuggestCoverage,BOPEntityInlineQSPageClickRate,BOPEntityInlineQSConditionalClickRate,BOPEntityInlineQSCoverage,ComparePageClickRate,CompareConditionalClickRate,CompareCoverage,CoreBottomAdPageClickRate,CoreBottomAdConditionalClickRate,CoreBottomAdCoverage,CoreBottomPageClickRate,CoreBottomConditionalClickRate,CoreBottomCoverage,CorePageClickRate,CoreConditionalClickRate,CoreCoverage,CoreResultsDocPreview2OrMorePageClickRate,CoreResultsDocPreview2OrMoreConditionalClickRate,CoreResultsDocPreview2OrMoreCoverage,CoreResultsDocPreview3OrMorePageClickRate,CoreResultsDocPreview3OrMoreConditionalClickRate,CoreResultsDocPreview3OrMoreCoverage,CoreResultsDocPreview4OrMorePageClickRate,CoreResultsDocPreview4OrMoreConditionalClickRate,CoreResultsDocPreview4OrMoreCoverage,CoreResultsDocPreview5OrMorePageClickRate,CoreResultsDocPreview5OrMoreConditionalClickRate,CoreResultsDocPreview5OrMoreCoverage,CoreResultsDocPreviewEmbeddedPageClickRate,CoreResultsDocPreviewEmbeddedConditionalClickRate,CoreResultsDocPreviewEmbeddedCoverage,CoreResultsDocPreviewPageClickRate,CoreResultsDocPreviewConditionalClickRate,CoreResultsDocPreviewCoverage,CoreTopAdPageClickRate,CoreTopAdConditionalClickRate,CoreTopAdCoverage,CoreTopPageClickRate,CoreTopConditionalClickRate,CoreTopCoverage,CorrectionPageClickRate,CorrectionConditionalClickRate,CorrectionCoverage,DCardAnswerPageClickRate,DCardAnswerConditionalClickRate,DCardAnswerCoverage,DCardPageClickRate,DCardConditionalClickRate,DCardCoverage,DCardWebIndexDeeplinkPageClickRate,DCardWebIndexDeeplinkConditionalClickRate,DCardWebIndexDeeplinkCoverage,DCardWebIndexExternalWebSearchPageClickRate,DCardWebIndexExternalWebSearchConditionalClickRate,DCardWebIndexExternalWebSearchCoverage,DCardWebIndexPackageSearchPageClickRate,DCardWebIndexPackageSearchConditionalClickRate,DCardWebIndexPackageSearchCoverage,DCardWebIndexPageClickRate,DCardWebIndexConditionalClickRate,DCardWebIndexCoverage,DCardWebIndexSiteSearchPageClickRate,DCardWebIndexSiteSearchConditionalClickRate,DCardWebIndexSiteSearchCoverage,DCardWebIndexTitleLinkPageClickRate,DCardWebIndexTitleLinkConditionalClickRate,DCardWebIndexTitleLinkCoverage,DominantResultWebIndexPageClickRate,DominantResultWebIndexConditionalClickRate,DominantResultWebIndexCoverage,ECardAnswerRowPageClickRate,ECardAnswerRowConditionalClickRate,ECardAnswerRowCoverage,ECardBlurbPageClickRate,ECardBlurbConditionalClickRate,ECardBlurbCoverage,ECardDominantImagePageClickRate,ECardDominantImageConditionalClickRate,ECardDominantImageCoverage,ECardFreshContentPageClickRate,ECardFreshContentConditionalClickRate,ECardFreshContentCoverage,ECardFreshContentRssAnswerPageClickRate,ECardFreshContentRssAnswerConditionalClickRate,ECardFreshContentRssAnswerCoverage,ECardPageClickRate,ECardConditionalClickRate,ECardCoverage,EntityResultsCachedPageLinkPageClickRate,EntityResultsCachedPageLinkConditionalClickRate,EntityResultsCachedPageLinkCoverage,EntityResultsEnhancedViewLinkPageClickRate,EntityResultsEnhancedViewLinkConditionalClickRate,EntityResultsEnhancedViewLinkCoverage,EntityResultsSiteDataLinkPageClickRate,EntityResultsSiteDataLinkConditionalClickRate,EntityResultsSiteDataLinkCoverage,EntityResultsSpamLinkPageClickRate,EntityResultsSpamLinkConditionalClickRate,EntityResultsSpamLinkCoverage,EntityResultsTranslateLinkPageClickRate,EntityResultsTranslateLinkConditionalClickRate,EntityResultsTranslateLinkCoverage,EntityResultsWebIndexTitleLinkPageClickRate,EntityResultsWebIndexTitleLinkConditionalClickRate,EntityResultsWebIndexTitleLinkCoverage,FooterPageClickRate,FooterConditionalClickRate,FooterCoverage,HeaderPageClickRate,HeaderConditionalClickRate,HeaderCoverage,HighMonetizationQuerySuggestionsPageClickRate,HighMonetizationQuerySuggestionsConditionalClickRate,HighMonetizationQuerySuggestionsCoverage,InlineAnswerPageClickRate,InlineAnswerConditionalClickRate,InlineAnswerCoverage,InlineECardPageClickRate,InlineECardConditionalClickRate,InlineECardCoverage,InlineQSPageClickRate,InlineQSConditionalClickRate,InlineQSCoverage,ItemPageClickRate,ItemConditionalClickRate,ItemCoverage,LeftRailExploreRelatedPageClickRate,LeftRailExploreRelatedConditionalClickRate,LeftRailExploreRelatedCoverage,LeftRailPageClickRate,LeftRailConditionalClickRate,LeftRailCoverage,MOPEntityInlineQSPageClickRate,MOPEntityInlineQSConditionalClickRate,MOPEntityInlineQSCoverage,NavBarHeaderPageTitlePageClickRate,NavBarHeaderPageTitleConditionalClickRate,NavBarHeaderPageTitleCoverage,NavBarPageClickRate,NavBarConditionalClickRate,NavBarCoverage,PaginationPageClickRate,PaginationConditionalClickRate,PaginationCoverage,PromoteIEPageClickRate,PromoteIEConditionalClickRate,PromoteIECoverage,RecentSearchHistoryPageClickRate,RecentSearchHistoryConditionalClickRate,RecentSearchHistoryCoverage,RelatedPageClickRate,RelatedConditionalClickRate,RelatedCoverage,RelatedQSComparePageClickRate,RelatedQSCompareConditionalClickRate,RelatedQSCompareCoverage,RelatedQSDefaultPageClickRate,RelatedQSDefaultConditionalClickRate,RelatedQSDefaultCoverage,RelevantSearchHistoryPageClickRate,RelevantSearchHistoryConditionalClickRate,RelevantSearchHistoryCoverage,ResultForceToBottomAnswerPageClickRate,ResultForceToBottomAnswerConditionalClickRate,ResultForceToBottomAnswerCoverage,ResultsPos01PageClickRate,ResultsPos01ConditionalClickRate,ResultsPos01Coverage,ResultsPos02PageClickRate,ResultsPos02ConditionalClickRate,ResultsPos02Coverage,ResultsPos03PageClickRate,ResultsPos03ConditionalClickRate,ResultsPos03Coverage,ResultsPos04PageClickRate,ResultsPos04ConditionalClickRate,ResultsPos04Coverage,ResultsPos05PageClickRate,ResultsPos05ConditionalClickRate,ResultsPos05Coverage,ResultsPos06PageClickRate,ResultsPos06ConditionalClickRate,ResultsPos06Coverage,ResultsPos07PageClickRate,ResultsPos07ConditionalClickRate,ResultsPos07Coverage,ResultsPos08PageClickRate,ResultsPos08ConditionalClickRate,ResultsPos08Coverage,ResultsPos09PageClickRate,ResultsPos09ConditionalClickRate,ResultsPos09Coverage,ResultsPos10PageClickRate,ResultsPos10ConditionalClickRate,ResultsPos10Coverage,ResultsPageClickRate,ResultsConditionalClickRate,ResultsCoverage,RichAdPageClickRate,RichAdConditionalClickRate,RichAdCoverage,RightRailAdPageClickRate,RightRailAdConditionalClickRate,RightRailAdCoverage,RightRailPageClickRate,RightRailConditionalClickRate,RightRailCoverage,ScopeBarPageClickRate,ScopeBarConditionalClickRate,ScopeBarCoverage,SearchHistoryPageClickRate,SearchHistoryConditionalClickRate,SearchHistoryCoverage,SetBingDefaultsPageClickRate,SetBingDefaultsConditionalClickRate,SetBingDefaultsCoverage,SetHomepagePageClickRate,SetHomepageConditionalClickRate,SetHomepageCoverage,SetSearchEnginePageClickRate,SetSearchEngineConditionalClickRate,SetSearchEngineCoverage,TaskSharingPageClickRate,TaskSharingConditionalClickRate,TaskSharingCoverage,TOCPageClickRate,TOCConditionalClickRate,TOCCoverage,TOCTOCAlgorithmicPageClickRate,TOCTOCAlgorithmicConditionalClickRate,TOCTOCAlgorithmicCoverage,TOCTOCEditorialPageClickRate,TOCTOCEditorialConditionalClickRate,TOCTOCEditorialCoverage,TOCVerticalNavPageClickRate,TOCVerticalNavConditionalClickRate,TOCVerticalNavCoverage,TOCWebGroupPageClickRate,TOCWebGroupConditionalClickRate,TOCWebGroupCoverage,TopAnswerPageClickRate,TopAnswerConditionalClickRate,TopAnswerCoverage,TopECardPageClickRate,TopECardConditionalClickRate,TopECardCoverage,TOPEntityInlineQSPageClickRate,TOPEntityInlineQSConditionalClickRate,TOPEntityInlineQSCoverage,WebIndexDeeplinkPageClickRate,WebIndexDeeplinkConditionalClickRate,WebIndexDeeplinkCoverage,WebIndexPageClickRate,WebIndexConditionalClickRate,WebIndexCoverage,AvgTimeToFirstClick,AvgTimeToLastClick,AdClickYield,CoreBottomAdClickYield,CoreTopAdClickYield,RightRailAdClickYield,AdCPC,AdDensity,CoreBottomAdDensity,CoreResultsDocPreviewEmbeddedDensity,CoreTopAdDensity,RightRailAdDensity,AnswerBarDensity,NoResultRate,RelatedDensity,RelatedQSCompareDensity,RelatedQSDefaultDensity,WholePageClickRate,WholePageConditionalClickRate,AutosuggestFollowOnConditionalClickRate,ActivityListRegionEngagementRate,ExpandoOpenRate,ExpertListRegionEngagementRate,RelevantPeopleListRegionEngagementRate,RightPaneEngagementRate,RightPanePersonalizedDataEngagementRate,RPM,ActivityListRegionCoverage,AllRichCaptionConditionalClickRate,AllRichCaptionCoverage,AnswerClickYield,BlogAnswerClickYield,BlogAnswerConditionalClickRate,BlogAnswerCoverage,BlogAnswerPageClickRate,ChildAnswerConditionalClickRate,ChildAnswerCoverage,CommerceAnswerClickYield,CommerceAnswerConditionalClickRate,CommerceAnswerCoverage,CommerceAnswerPageClickRate,DCardClickYield,ECardClickYield,ExpandoCoverage,ExpertListRegionCoverage,FilterBarConditionalClickRate,FilterBarCoverage,FinanceAnswerClickYield,FinanceAnswerConditionalClickRate,FinanceAnswerCoverage,FinanceAnswerPageClickRate,ImageAnswerClickYield,ImageAnswerConditionalClickRate,ImageAnswerCoverage,ImageAnswerPageClickRate,InlineAnswerClickYield,IntegratedSearchFeatureConditionalClickRate,IntegratedSearchFeatureCoverage,MapsAnswerClickYield,MapsAnswerConditionalClickRate,MapsAnswerCoverage,MapsAnswerPageClickRate,NewsAnswerClickYield,NewsAnswerConditionalClickRate,NewsAnswerCoverage,NewsAnswerPageClickRate,PhonebookAnswerClickYield,PhonebookAnswerConditionalClickRate,PhonebookAnswerCoverage,PhonebookAnswerPageClickRate,RelevantPeopleListRegionCoverage,ResultForceToBottomAnswerClickYield,RightPaneConditionalClickRate,RightPaneCoverage,RightPanePersonalizedDataCoverage,SongsAnswerClickYield,SongsAnswerConditionalClickRate,SongsAnswerCoverage,SongsAnswerPageClickRate,TaskPaneConditionalClickRate,TaskPaneCoverage,TOPAnswerClickYield,VideoAnswerClickYield,VideoAnswerConditionalClickRate,VideoAnswerCoverage,VideoAnswerPageClickRate,WeatherAnswerClickYield,WeatherAnswerConditionalClickRate,WeatherAnswerCoverage,WeatherAnswerPageClickRate,WebIndexClickYield,WebIndexDeeplinkClickYield,WholePageClickYield,TurnkeyPageRegion,TurnkeyService,TurnkeyScenario,TurnkeyItemCount,TurnkeyClickCount,TurnkeyItemPresent,TurnkeyClickPresent,TurnkeySuccessClickPresent,TurnkeySuccessClickCount,TurnkeyQuickbackClickPresent,TurnkeyQuickbackClickCount,TurnkeyDataSourceService,TurnkeyDataSourceScenario,OverallPLT_Percentile20,OverallPLT_Percentile25,OverallPLT_Percentile30,OverallPLT_Percentile35,OverallPLT_Percentile40,OverallPLT_Percentile45,OverallPLT_Percentile50,OverallPLT_Percentile55,OverallPLT_Percentile60,OverallPLT_Percentile65,OverallPLT_Percentile70,OverallPLT_Percentile75,OverallPLT_Percentile80,OverallPLT_Percentile85,OverallPLT_Percentile90,OverallPLT_Percentile95,OverallPLT_Percentile99,HomepageSearchBoxCCR,HomepageHotspotsCCR,HomepageScopeBarCCR,HomepageTBOverallCCR,HomepageTBPopNowTileCCR,HomepageSetDHPCCR";
var dataColumnNameArray = input.Split(new char[]{','}).ToArray();

var bft = XElement.Load (@"BFT-old.xml");

// get the columns that are in the blacklist but not required by Rover
var tbcDataColumnNameArray = 
	bft.Descendants("DataColumn")
		.Where(c => dataColumnNameArray.Contains( c.Attribute("Name").Value ))
		.Where(c => c.Element("Definition") != null)
		.Select(c => c.Attribute("Name").Value).ToArray();

tbcDataColumnNameArray.Dump();

var tbcDataColumnNameIdArray = DataColumnNames.Where(c => tbcDataColumnNameArray.Contains(c.Name)).Select(c => c.DataColumnNameId).ToArray();

V_DataColumn.Where(c => tbcDataColumnNameArray.Contains( c.DataColumnName )).Select (c => c.DataSetName).Distinct().Dump();

// DataColumnDependencies.Where(c => tbcDataColumnNameIdArray.Contains(c.SourceDataColumnId)).Dump();