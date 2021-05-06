using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AktivStyringRazor.Models;

namespace AktivStyringRazor.Services.Interfaces
{
    public interface INodeService
    {
        Task<List<Node>> GetNoderAsync();
        Task<bool> AddNodeAsync(Node node);
        Task<Node> GetNodeByIdAsync(int musikID);
        Task<Node> DeleteNodeAsync(int musikID);
        //Task<List<Node>> GetNodeByNavnAsync();
    }
}
