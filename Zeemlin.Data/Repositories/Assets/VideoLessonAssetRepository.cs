﻿using Zeemlin.Data.DbContexts;
using Zeemlin.Data.IRepositries.Assets;
using Zeemlin.Domain.Entities.Assets;

namespace Zeemlin.Data.Repositories.Assets;

public class VideoLessonAssetRepository : Repository<VideoLessonAsset>, IVideoLessonAssetRepository
{
    public VideoLessonAssetRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
