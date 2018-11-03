/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:

	
	config.language = 'vi';
	// config.uiColor = '#AADC6E';
	config.filebrowserBrowseUrl = 'ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Assets/Plugins/ckfinder/ckfinder/ckfinder.html?type=Images';
	config.filebrowserFlashBrowseUrl = '/Assets/Plugins/ckfinder/ckfinder.html?type=Flash';
	config.filebrowserUploadUrl = '/Assets/Plugins/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Assets/Plugins/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images';
	config.filebrowserFlashUploadUrl = '/Assets/Plugins/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Flash';
	CKFinder.setupCKEditor(null, '/Assets/Plugins/ckfinder/');
};
