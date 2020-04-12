<?php

$postCount = 10; 

if($_GET["postCount"] != "")
{ 
    $postCount =$_GET["postCount"];  
}

if ( !defined('ABSPATH') ) {
	/** Set up WordPress environment */
	require_once( dirname( __FILE__ ) . '/wp-load.php' );
}


function CleanContent( $content ) {
    return ($content) ;
}

$posts = query_posts('showposts=' . $postCount);

$response = array();
$idxItem = 0;

while ( have_posts() ) : the_post();

    $response[$idxItem] = array(
        'id' => get_the_ID(),
        'slug' => get_post_field( 'post_name', get_post() ),
        'title' => get_the_title(),
        'content' => CleanContent( get_the_content() ),
        'link'=> get_the_permalink(),
        'category' => get_the_category(),
        'tags' => get_the_tags(),
        'pubDate' => mysql2date('D, d M Y H:i:s +0000', get_post_time('Y-m-d H:i:s', true), false),
        'dcCreator' => get_the_author(),
        'seo_metadesc' => get_post_meta(get_the_ID(), '_yoast_wpseo_metadesc', true),
        'seo_focuskw' => get_post_meta(get_the_ID(), '_yoast_wpseo_focuskw', true),
        'seo_image' => get_the_post_thumbnail_url(),
    );

$idxItem +=1;

endwhile;


header("Content-Type: application/json");
echo json_encode($response); 
?>