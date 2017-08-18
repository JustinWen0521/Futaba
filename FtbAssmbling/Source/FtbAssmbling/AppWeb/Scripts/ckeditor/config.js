/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.htmlEncodeOutput = true;
    config.font_names = '新細明體;標楷體;微軟正黑體;' + CKEDITOR.config.font_names;
    config.font_defaultLabel = '新細明體'; //默認的字體名
};
