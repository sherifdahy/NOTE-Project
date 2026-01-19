using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace NOTE.Solutions.Entities.Entities.Identity;

public class ApplicationUserContexts
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public int ContextId { get; set; }
    public Context Context { get; set; } = default!;
}
