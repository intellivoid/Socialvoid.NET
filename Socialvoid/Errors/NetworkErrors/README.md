# NetworkErrors

These are the catch-all errors when dealing with the network, from 
finding peers, following them, posting, etc. 

| Name            | Code  | Hex Code | Deprecated | Versions | Description                                                                            |
|-----------------|-------|----------|------------|----------|----------------------------------------------------------------------------------------|
| PeerNotFound    | 12544 | 0x03100  | No         | 1.0      | The requested user entity was not found in the network                                 |
| PostNotFound    | 12545 | 0x03101  | No         | 1.0      | Raised when the client requested a post that isn't found                               |
| PostDeleted     | 12546 | 0x03102  | No         | 1.0      | Raised when the client requested a post that was deleted                               |
| AlreadyReposted | 12547 | 0x03103  | No         | 1.0      | Raised when the client attempts to repost a post that has already been reposted        |
| FileUploadError | 12548 | 0x03104  | No         | 1.0      | Raised when there was an error while trying to upload one or more files to the network |