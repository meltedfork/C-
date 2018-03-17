SELECT comments.comment, messages.message, users.firstname, users.lastname, comments.created_at, comments.messages_id
FROM comments 
INNER JOIN messages ON messages.id=comments.messages_id
INNER JOIN users ON comments.users_id=users.id
ORDER BY comments.created_at DESC
