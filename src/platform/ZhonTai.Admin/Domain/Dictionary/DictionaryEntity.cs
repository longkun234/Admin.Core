﻿using ZhonTai.Admin.Core.Entities;
using FreeSql.DataAnnotations;
using ZhonTai.Admin.Domain.DictionaryType;

namespace ZhonTai.Admin.Domain.Dictionary;

/// <summary>
/// 数据字典
/// </summary>
[Table(Name = "ad_dictionary")]
[Index("idx_{tablename}_01", nameof(DictionaryTypeId) + "," + nameof(Name) + "," + nameof(TenantId), true)]
public partial class DictionaryEntity : EntityTenant
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public long DictionaryTypeId { get; set; }

    /// <summary>
    /// 字典类型
    /// </summary>
    public DictionaryTypeEntity DictionaryType { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    [Column(StringLength = 50)]
    public string Name { get; set; }

    /// <summary>
    /// 字典编码
    /// </summary>
    [Column(StringLength = 50)]
    public string Code { get; set; }

    /// <summary>
    /// 字典值
    /// </summary>
    [Column(StringLength = 50)]
    public string Value { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [Column(StringLength = 500)]
    public string Description { get; set; }

    /// <summary>
    /// 启用
    /// </summary>
	public bool Enabled { get; set; } = true;

    /// <summary>
    /// 排序
    /// </summary>
	public int Sort { get; set; }
}